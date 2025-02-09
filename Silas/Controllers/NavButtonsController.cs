using Microsoft.AspNetCore.Mvc;
using Silas.Models.Offers;
using Silas.Models.Student;
using Silas.ViewModels;

namespace Silas.Controllers
{
    public class NavButtonsController : Controller
    {

        private readonly StudentService _studentService;

        public NavButtonsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> OnClick(string vacio, string title, int id)
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

                default:
                    return PartialView("StudentApplies");
            }
        }
    }
}
