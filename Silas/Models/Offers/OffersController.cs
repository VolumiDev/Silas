using Microsoft.AspNetCore.Mvc;
using Silas.Models.Offers;
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

        //DETALLES
        //public async Task<IActionResult> Details(int id)
        //{
        //    var offer = await _offerService.GetOfferByIdAsync(id);
        //    if (offer == null)
        //    {
        //        return NotFound();
        //    }
        //    //Devuelve la vista Details, la cual usará el layout _GenericLayout
        //    return View(offer);
        //}
    }
}
