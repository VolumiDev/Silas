using Microsoft.AspNetCore.Mvc;
using Silas.Models.Courses;
using Silas.Models.Offers;
using Silas.Models.Student;
using Silas.ViewModels;

namespace Silas.Controllers
{
    public class NavButtonsController : Controller
    {

        private readonly StudentService _studentService;
        private readonly OfferService _offerService;
        private readonly CourseService _courseService;
        public NavButtonsController(StudentService studentService, OfferService offerService, CourseService courseService)
        {
            _studentService = studentService;
            _offerService = offerService;
            _courseService = courseService;
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

                //DETALLES DE LA OFERTA "X" SELECCIONADA EN "LeftPanel"
                case "OfertaDetalle":
                    
                    var offer = await _offerService.GetOfferDetailsAsync(id);
                    if (offer == null)
                    {
                        return PartialView("ErrorPartial", "Oferta no encontrada");
                    }
                    var offerModel = new OfferDetailsViewModel { OfferData = offer };
                    //NO FUNCIONA CON SOLAMENTE "OfferDetails", TENGO Q PONER LA RUTA
                    return PartialView("~/Views/Offers/OfferDetails.cshtml", offerModel);

                //MOSTRAR OFERTAS DE UNA EMPRESA
                case "Mis ofertas":
                    var offers=await _offerService.GetOffersByCompanyIdAsync(id);

                    return PartialView("CompanyOffers",offers);

                case "NewOfferForm":

                    var cursos = await _courseService.GetCoursesAsync();

                    if (cursos == null)
                    {
                        cursos = new List<Course>();
                    }

                    var newoffermodel = new NewOfferViewModel
                    {
                        Title = title,
                        IdCompany = id,
                        Offer= new OfferInsert(),
                        Courses = cursos
                    };
                    return PartialView("NewOfferForm",newoffermodel);

                default:
                    return PartialView("StudentApplies");
            }
        }
    }
}
