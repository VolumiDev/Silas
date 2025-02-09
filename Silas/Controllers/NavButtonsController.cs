using Microsoft.AspNetCore.Mvc;
using Silas.Models.Offers;
using Silas.Models.Student;
using Silas.ViewModels;

namespace Silas.Controllers
{
    public class NavButtonsController : Controller
    {

        private readonly StudentService _studentService;
        private readonly OfferService _offerService;

        public NavButtonsController(StudentService studentService, OfferService offerService)
        {
            _studentService = studentService;
            _offerService = offerService;
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




                default:
                    return PartialView("StudentApplies");
            }
        }
    }
}
