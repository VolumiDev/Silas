using Microsoft.AspNetCore.Mvc;
using Silas.Models.Companies;
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

        public NavButtonsController(StudentService studentService, OfferService offerService, CompanyService companyService)
        {
            _studentService = studentService;
            _offerService = offerService;
            this._companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> OnClick(string vacio, string title, int id, int cid=0)
        {
            switch (title)
            {
                case "Ofertas":

                    var response =await _studentService.GetOffersToStodent(id);
                    var model = new OffersToStudentProfileViewModel
                    {
                        OffersList = response.Offers
                    };

                    return PartialView("StudentOffers", model);

                case "Inicio":
                    return PartialView("StudentHome");

                case "Soporte":
                    return PartialView("StudentSupport");


                //DETALLES DE LA OFERTA "X" SELECCIONADA EN "LeftPanel"
                case "OfertaDetalle":
                    
                    var offer = await _offerService.GetOfferDetailsAsync(id);

                    var offerModel = new OfferDetailsViewModel { OfferData = offer };
                    //NO FUNCIONA CON SOLAMENTE "OfferDetails", TENGO Q PONER LA RUTA
                    return PartialView("~/Views/NavButtons/OfferDetails.cshtml", offerModel);

                case "OfertaFullDetalle":
                    {
                        // Muestra detalles completos: oferta + aplicaciones
                        var fullOffer = await _offerService.GetOfferDetailsAsync(id);
                        var fullOfferModel = new OfferFullDetailsViewModel
                        {
                            OfferData = fullOffer,
                            Applications = await _offerService.GetOfferApplicationsAsync(id)
                        };
                        return PartialView("~/Views/NavButtons/OfferFullDetails.cshtml", fullOfferModel);

                    }
                //MODIFICAR OFERTA
                case "OfertaModificar":
                    {
                        // Carga el formulario de edición de la oferta.
                        var offerToEdit = await _offerService.GetOfferDetailsAsync(id);
                        if (offerToEdit == null)
                            return NotFound();
                        return PartialView("EditOffer", offerToEdit);
                    }

                //ELIMINAR OFERTA
                case "OfertaEliminar":
                    {
                        var offerToShow = await _offerService.GetOfferDetailsAsync(id);

                        bool deleteResult = await _offerService.DeleteOfferAsync(id);
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
                    var company = await _companyService.GetCompanyByIdAsync(id);
                    var offers = await _offerService.GetOffersByCompanyIdAsync(id);
                    var companyDetailsModel = new CompanyDetailsViewModel
                    {
                        Company = company,
                        Offers = offers
                    };
                    return PartialView("CompanyDetails", companyDetailsModel);

                    //MODIFICAR EMPRESA
                case "EmpresaModificar":
                    var companyToEdit = await _companyService.GetCompanyByIdAsync(id);
                    if (companyToEdit == null)
                        return NotFound();
                    return PartialView("CompanyEdit", companyToEdit);

                //DESACTIVAR EMPRESA
                case "EmpresaInactivar":
                        company = await _companyService.GetCompanyByIdAsync(id);
                    if (company == null)
                    {
                        return NotFound();
                    }
                    var result = await _companyService.DeactivateCompanyAsync(id);
                    if (result)
                    {
                        return PartialView("CompanyDeactivate", company);
                    }
                    else
                    {
                        return BadRequest("No se pudo inactivar la empresa.");
                    }




                default:
                    return PartialView("StudentApplies");
            }
        }
    }
}
