using Microsoft.AspNetCore.Mvc;
using Silas.Models.Companies;
using Silas.Models.Offers;
using Silas.Models.Student;
using Silas.ViewModels;
using System.Threading.Tasks;

namespace Silas.Controllers
{
    public class DashboardController : Controller
    {
        private readonly CompanyService _companyService;
        private readonly OfferService _offerService;
        private readonly StudentService _studentService;

        public DashboardController(CompanyService companyService, OfferService offerService, StudentService studentService)
        {
            _companyService = companyService;
            _offerService = offerService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var companies = await _companyService.ListAllCompaniesAsync();
            int companiesCount = companies?.Count ?? 0;

            var offersList = await _offerService.GetLatestOffersForAdminAsync();
            int offersCount = offersList?.Count ?? 0;

            //var studentsList = await _studentService.GetAllStudentsAsync(); FALTA ESTE PHP
            //int studentsCount = studentsList?.Count ?? 0;

            int applicationsCount = 0;
            foreach (var offer in offersList)
            {
                var apps = await _offerService.GetOfferApplicationsAsync(offer.id);
                applicationsCount += apps.Count;
            }

            var model = new DashboardViewModel
            {
                CompaniesCount = companiesCount,
                OffersCount = offersCount,
                //StudentsCount = studentsCount,
                ApplicationsCount = applicationsCount
            };

            return View(model);
        }
    }
}
