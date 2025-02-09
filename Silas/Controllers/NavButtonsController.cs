using Microsoft.AspNetCore.Mvc;
using Silas.Models.Student;

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
        public IActionResult OnClick(string title)
        {
            switch (title)
            {
                case "Ofertas":
                    return PartialView("StudentOffers");

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
