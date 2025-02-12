using Microsoft.AspNetCore.Mvc;
using Silas.Models;
using Silas.Models.Companies;
using Silas.Models.Offers;
using Silas.ViewModels;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Silas.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;
        private readonly OfferService _offerService;

        public CompanyController(CompanyService companyService, OfferService offerService)
        {
            _companyService = companyService;
            _offerService = offerService;
        }

        //LISTADO DE TODAS LAS EMPRESAS SIN EXCEPCIÓN
        public async Task<IActionResult> Index()
        {
            var companies = await _companyService.ListAllCompaniesAsync();
            return View(companies);
        }


        //GET Q MUESTRA EL FORMULARIO DE EDICIÓN DE "COMPANY"
        public async Task<IActionResult> Edit(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            return PartialView("~/Views/NavButtons/CompanyEdit.cshtml", company);
        }

        //POST q recibe el modelo Company para actualizar
        [HttpPost]
        public async Task<IActionResult> Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                bool result = await _companyService.UpdateCompanyAsync(company);
                if (result)
                {
                    return RedirectToAction("OnClick", "NavButtons", new { title = "EmpresaDetalle", id = company.IdUser });
                }
            }
            return View("~/Views/NavButtons/CompanyEdit.cshtml", company);
        }


        //PASAR UNA EMPRESA SU "STATUS" A 0
        [HttpPost]
        public async Task<IActionResult> Deactivate(int id)
        {
            var result = await _companyService.DeactivateCompanyAsync(id);
            if (result)
                return RedirectToAction("Index");
            return BadRequest();
        }

        //ESTO DA ERROR, LO COMENTO
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // Get mostrar perfil en modo lectura
        public async Task<IActionResult> Profile(int id)
        {
            var company = await _companyService.GetCompanyProfileByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return PartialView("~/Views/NavButtons/ProfileCompany.cshtml", company);
        }
        //Modificar Perfil
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(Company company)
        {
            if (!ModelState.IsValid)
            {
                // Retorna un error o la vista con validaciones si hay datos no válidos
                return BadRequest(ModelState);
            }

            // Actualiza la empresa en la base de datos mediante el servicio.
            bool updateResult = await _companyService.UpdateCompanyProfileAsync(company);
            if (!updateResult)
            {
                return StatusCode(500, "Error updating company profile.");
            }

            // Vuelve a cargar el perfil actualizado (usando el servicio para obtener los datos actualizados)
            var updatedCompany = await _companyService.GetCompanyProfileByIdAsync(company.IdUser);
            return PartialView("~/Views/NavButtons/ProfileCompany.cshtml", updatedCompany);
        }


        //ESTO LO MANTEGNO
        public IActionResult LeftPanel()
        {
            return View();
        }

    }
}
