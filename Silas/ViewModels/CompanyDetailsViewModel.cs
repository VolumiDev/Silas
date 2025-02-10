using System.Collections.Generic;
using Silas.Models;
using Silas.Models.Offers;

namespace Silas.ViewModels
{
    public class CompanyDetailsViewModel
    {
        public Company Company { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
