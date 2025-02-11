using System.Collections.Generic;
using Silas.Models.Offers;

namespace Silas.ViewModels
{
    public class OfferFullDetailsViewModel
    {
        //ESTE TAMBIEN RECOGE LOS Q HAN APLICADO A ESTA OFERTA
        public Offer OfferData { get; set; }
        public List<OfferApplicationViewModel> Applications { get; set; }
    }
}
