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
                var result = await _companyService.UpdateCompanyAsync(company);
                if (result)
                    // Redirige al listado de empresas
                    return RedirectToAction("OnClick", "NavButtons", new { actionName = "Ver Empresas" });
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


        //ESTO LO MANTEGNO
        public IActionResult LeftPanel()
        {
            return View();
        }

    }
}
