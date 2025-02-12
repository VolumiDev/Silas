using Silas.Models.Offers;
using Silas.Models.Applies;

namespace Silas.ViewModels
{
    public class OffersToStudentProfileViewModel
    {
        public List<OffersToStudentProfile> OffersList { get; set; }

        public List<ApplyByStudent> AppliesList { get; set; }

        public List<ApplyToStudentProfile> AppliesToStudentProfile {  get; set; }
}
}
