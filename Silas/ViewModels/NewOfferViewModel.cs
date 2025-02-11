using Silas.Models.Courses;
using Silas.Models.Offers;

namespace Silas.ViewModels
{
    public class NewOfferViewModel
    {
        public string Title { get; set; }
        public int IdCompany { get; set; }
        public OfferInsert Offer { get; set; }

        public List<Course> Courses { get; set; }

    }
}
