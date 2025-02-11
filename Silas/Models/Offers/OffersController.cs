using Microsoft.AspNetCore.Mvc;
using Silas.Models.Offers;
using Silas.ViewModels;
using System.Reflection;
using System.Threading.Tasks;

namespace Silas.Controllers
{
    public class OffersController : Controller
    {
        private readonly OfferService _offerService;

        public OffersController(OfferService offerService)
        {
            _offerService = offerService;
        }

        //DETALLES DE 1 OFERTA EN CONCRETO
        public async Task<IActionResult> Details(int id)
        {
            var offer = await _offerService.GetOfferDetailsAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            var modelo = new OfferDetailsViewModel
            {
                OfferData = offer,
            };

            return View("OfferDetails", modelo);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOffer([FromBody] OfferInsert offer) {


            var response = await _offerService.CreateOfferAsync(offer);
            if (response)
            {
                return Json(new { success = true, message = "Inserción exitosa" });
            }
            else
            {
                return Json(new { success = false, message = "Error en la inserción" });
            }


        }



    }
}
