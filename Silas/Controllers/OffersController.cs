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
            bool updated = await _offerService.UpdateOfferAsync(offer);
            if (updated)
            {
                return Json(new { success = true, companyId = offer.id_company });
            }
            return Json(new { success = false, error = "No se pudo actualizar la oferta." });
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
        
        //LOS DETALLES DE LA OFERTA CON LOS ALUMNOS Q HAY APLICADOS
        public async Task<IActionResult> FullDetails(int id)
        {
            var offer = await _offerService.GetOfferDetailsAsync(id);
            var applications = await _offerService.GetOfferApplicationsAsync(id);
            var model = new OfferFullDetailsViewModel
            {
                OfferData = offer,
                Applications = applications
            };
            return View("OfferFullDetails", model);
        }


        //CREACION DE UNA NUEVA OFERTA POR PARTE DE UNA EMPRESA
        [HttpPost]
        public async Task<IActionResult> CreateOffer([FromBody] OfferInsert offer)
        {


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

        [HttpPost]
        public IActionResult OfferApply(int id)
        {
            return RedirectToAction("OnClick", "NavButtonsController", new { vacio = "", actionName = "Ofertas", superID = id, cid = 0 });
        }




    }
}
