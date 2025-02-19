﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Silas.Models.Companies;
using Silas.Models.Courses;
using Silas.Models.Offers;
using Silas.Models.Student;
using Silas.ViewModels;
using System.Security.Cryptography;

namespace Silas.Controllers
{
    public class NavButtonsController : Controller
    {

        private readonly StudentService _studentService;
        private readonly OfferService _offerService;
        private readonly CompanyService _companyService;

        private readonly CourseService _courseService;
        public NavButtonsController(StudentService studentService, OfferService offerService, CourseService courseService, CompanyService companyService)
        {
            _studentService = studentService;
            _offerService = offerService;
            _courseService = courseService;
            this._companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> OnClick(int auxId, string actionName, int superID, int cid=0)
        {
            switch (actionName)
            {
                case "Ofertas":

                    var response =await _studentService.GetOffersToStudent(superID);

                    var apliesResponse = await _studentService.ListAplliesByStudentId(superID);

                    var model = new OffersToStudentProfileViewModel
                    {
                        OffersList = response.Offers
                    };

                    return PartialView("StudentOffers", model);

                case "Inicio":
                    {
                        var companies2 = await _companyService.ListAllCompaniesAsync();
                        int companiesCount = companies2?.Count ?? 0;

                        var offersList = await _offerService.GetLatestOffersForAdminAsync(); 
                        int offersCount = offersList?.Count ?? 0;

                        //STUDENTS NO ESTÁ FUNCIONANDO FALTA EL PHP
                        var students = await _studentService.GetAllStudentsAsync();
                        int studentsCount = students?.Count ?? 0;

                        int applicationsCount = 0;
                        foreach (var offer2 in offersList)
                        {
                            var apps = await _offerService.GetOfferApplicationsAsync(offer2.id);
                            applicationsCount += apps.Count;
                        }

                        var dashboardModel = new DashboardViewModel
                        {
                            CompaniesCount = companiesCount,
                            OffersCount = offersCount,
                            StudentsCount = studentsCount, //NO ESTÁ FUNCIONANDO, FALTA EL PHP
                            ApplicationsCount = applicationsCount
                        };

                        return PartialView("Dashboard", dashboardModel);
                    }

                case "Soporte":
                    return PartialView("StudentSupport");


                //DETALLES DE LA OFERTA "X" SELECCIONADA EN "LeftPanel"
                case "OfertaDetalle":
                    
                    var offer = await _offerService.GetOfferDetailsAsync(superID);

                    var offerModel = new OfferDetailsViewModel { OfferData = offer };
                    //NO FUNCIONA CON SOLAMENTE "OfferDetails", TENGO Q PONER LA RUTA
                    return PartialView("~/Views/NavButtons/OfferDetails.cshtml", offerModel);

                case "OfertaFullDetalle":
                    {
                        // Muestra detalles completos: oferta + aplicaciones
                        var fullOffer = await _offerService.GetOfferDetailsAsync(superID);
                        var fullOfferModel = new OfferFullDetailsViewModel
                        {
                            OfferData = fullOffer,
                            Applications = await _offerService.GetOfferApplicationsAsync(superID)
                        };
                        return PartialView("~/Views/NavButtons/OfferFullDetails.cshtml", fullOfferModel);

                    }
                //MODIFICAR OFERTA
                case "OfertaModificar":
                    {
                        // Carga el formulario de edición de la oferta.
                        var offerToEdit = await _offerService.GetOfferDetailsAsync(superID);
                        if (offerToEdit == null)
                            return NotFound();
                        return PartialView("EditOffer", offerToEdit);
                    }

                //ELIMINAR OFERTA
                case "OfertaEliminar":
                    {
                        var offerToShow = await _offerService.GetOfferDetailsAsync(superID);

                        bool deleteResult = await _offerService.DeleteOfferAsync(superID);
                        if (deleteResult)
                        {
                            if (offerToShow == null)
                            {
                                //Construimos un fallback si la oferta ya no existe en la BD
                                offerToShow = new Offer { title = "Desconocido", id_company = 0 };
                            }
                            return PartialView("~/Views/NavButtons/OfferDeleted.cshtml", offerToShow);
                        }
                        else
                        {
                            //Error => OfferDeleteError.cshtml nos vamos a otra vista nueva de error donde tendremos también un botón para volver con ajax
                            if (offerToShow == null)
                            {
                                //Construimos un fallback si la oferta no existe
                                offerToShow = new Offer { title = "Desconocido", id_company = 0 };
                            }
                            return PartialView("~/Views/NavButtons/OfferDeleteError.cshtml", offerToShow);
                        }
                    }


                case "Ver Empresas":
                    //LISTADO DE EMPRESAS
                    var companies = await _companyService.ListAllCompaniesAsync();
                    return PartialView("CompanyList", companies);

                    //DETALLE DE UNA EMPRESA CONCRETA Y SUS OFERTAS
                case "EmpresaDetalle":
                    var company = await _companyService.GetCompanyByIdAsync(superID);
                    var offers = await _offerService.GetOffersByCompanyIdAsync(superID);
                    var companyDetailsModel = new CompanyDetailsViewModel
                    {
                        Company = company,
                        Offers = offers
                    };
                    return PartialView("CompanyDetails", companyDetailsModel);

                    //MODIFICAR EMPRESA
                case "EmpresaModificar":
                    var companyToEdit = await _companyService.GetCompanyByIdAsync(superID);
                    if (companyToEdit == null)
                        return NotFound();
                    return PartialView("CompanyEdit", companyToEdit);

                //DESACTIVAR EMPRESA
                case "EmpresaInactivar":
                        company = await _companyService.GetCompanyByIdAsync(superID);
                    if (company == null)
                    {
                        return NotFound();
                    }
                    var result = await _companyService.DeactivateCompanyAsync(superID);
                    if (result)
                    {
                        return PartialView("CompanyDeactivate", company);
                    }
                    else
                    {
                        return BadRequest("No se pudo inactivar la empresa.");
                    }

                //MOSTRAR OFERTAS DE UNA EMPRESA
                case "Mis ofertas":
                    var offerJuan=await _offerService.GetOffersByCompanyIdAsync(superID);

                    return PartialView("CompanyOffers",offerJuan);

                case "NewOfferForm":

                    var cursos = await _courseService.GetCoursesAsync();

                    if (cursos == null)
                    {
                        cursos = new List<Course>();
                    }

                    var newoffermodel = new NewOfferViewModel
                    {
                        Title = actionName,
                        IdCompany = superID,
                        Offer= new OfferInsert(),
                        Courses = cursos
                    };
                    return PartialView("NewOfferForm",newoffermodel);


                // Perfil de Estudiante
                case "PerfilEstudiante":
                    var student = await _studentService.GetStudentByIdAsync(superID);
                    if (student == null)
                    {
                        return NotFound();
                    }

                    return PartialView("ProfileStudent", student);

                // Perfil de Empresa
                case "PerfilCompany":
                    var companyProfile = await _companyService.GetCompanyProfileByIdAsync(superID);
                    if (companyProfile == null)
                        return NotFound();

                    return PartialView("ProfileCompany", companyProfile);

                case "Soporte Empresa":
                    var companysupport = await _companyService.GetCompanyByIdAsync(superID);

                     return PartialView("CompanySupport",companysupport);

                case "StudentOfferAplication":

                    var formModel = new StudentOfferAplicationViewModel
                    {
                        Id = auxId,
                        IdOffer = superID,
                        Presentation = ""
                    };

                    //tenemos que mandar al formularion 
                    return PartialView("NewApplyForm", formModel);

                case "Mis apliques":

                    var appToStudentProf = await _studentService.GetAppliesToStudentProfileAsync(superID);

                    var modelAppliesList = new OffersToStudentProfileViewModel
                    {
                        AppliesToStudentProfile = appToStudentProf.Applies
                    };

                    return PartialView("StudentApplies", modelAppliesList);




                default:
                    return PartialView("StudentApplies");
            }
        }
    }
}
