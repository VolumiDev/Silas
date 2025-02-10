using Microsoft.AspNetCore.Mvc;
using Silas.Models.Companies;
using Silas.ViewModels;
using System.Threading.Tasks;

namespace Silas.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        //LISTADO DE TODAS LAS EMPRESAS SIN EXCEPCIÓN
        public async Task<IActionResult> Index()
        {
            var companies = await _companyService.ListAllCompaniesAsync();
            return View(companies);
        }

        //DETALLES DE LA EMPRESA "X" CON LISTADO DE OFFERTAS
        public async Task<IActionResult> Details(int id)
        {
            var details = await _companyService.GetCompanyByIdAsync(id);
            if (details == null)
                return NotFound();
            return View(details);
        }

        //VENIMOS DESDE LA VISTA "EDIT.CSHTML" Q PERMITE MODIFICAR TODOS LOS DATOS DE UNA EMPRESA, PODREMOS ACCEDER A ESA VISTA DESDE DOS LUGARES DISTINTOS
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _companyService.GetCompanyByIdAsync(id);
            if (details == null)
                return NotFound();
            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _companyService.UpdateCompanyAsync(model.Company);
                if (result)
                    return RedirectToAction("Details", new { id = model.Company.IdUser });
            }
            return View(model);
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
