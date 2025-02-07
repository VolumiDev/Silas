using Microsoft.AspNetCore.Mvc;
using Silas.Models;
using Silas.Models.Companies;
using Silas.Models.Offers;
using Microsoft.AspNetCore.Mvc.Formatters;
using Silas.Models;
using Silas.Models.Companies;
using Silas.Models.Offers;
using Silas.ViewModels;
using System.Reflection;


namespace Silas.ViewComponents
{
    public class LeftPanelViewComponent : ViewComponent
    {
        private readonly OfferService _offerService;

        public LeftPanelViewComponent(OfferService offerService)
        {
            _offerService = offerService;
        }


        public async Task<IViewComponentResult> InvokeAsync(string userRole, int userId)
        {
        
            if (userRole=="company")
            {
                List<Offer> offers = await _offerService.GetOffersByCompanyIdAsync(userId);
                var model = new LeftPanelViewModel
                {
                    userRole = userRole,
                    datalist = offers
                };

                return View("LeftPanel", model);
            }
            else if (userRole== "student")
            {
                List<Offer> last5Offers= await _offerService.GetCustomOffersForThisStudentAsync(userId);
                var model = new LeftPanelViewModel
                {
                    userRole = userRole,
                    datalist = last5Offers
                };
                return View("LeftPanel", model);
            }
            else
            {
                var model = new LeftPanelViewModel
                {
                    userRole = userRole,
                    datalist = []
                };
                //ESTE ES EL ADMIN, HAY QUE RETORNAR UNA VISTA EN TODOS
                return View("LeftPanel", model);
            }
        
        }
    }
}

