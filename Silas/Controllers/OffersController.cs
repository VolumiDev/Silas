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

        //EDITAR LOS DATOS DE UNA OFERTA "X"
        public async Task<IActionResult> EditOffer(int id)
        {
            var offer = await _offerService.GetOfferDetailsAsync(id);
            return View(offer);
        }

        [HttpPost]
        public async Task<IActionResult> EditOffer(Offer offer)
        {
            if (ModelState.IsValid)
            {
                var result = await _offerService.UpdateOfferAsync(offer);
                if (result)
                    return RedirectToAction("Details", "Company", new { id = offer.id_company });
            }
            return View(offer);
        }

        //ELIMINAR UNA OFERTA "X"
        [HttpPost]
        public async Task<IActionResult> DeleteOffer(int id, int companyId)
        {
            var result = await _offerService.DeleteOfferAsync(id);
            if (result)
                return RedirectToAction("Details", "Company", new { id = companyId });
            return BadRequest();
        }

        //LISTADO DE ALUMNOS QUE HAN APLICADO A LA OFERTA "X"
        public async Task<IActionResult> Applications(int id)
        {
            var applications = await _offerService.GetOfferApplicationsAsync(id);
            return View(applications);
        }



    }
}
