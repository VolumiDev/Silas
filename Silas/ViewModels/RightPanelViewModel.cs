using Silas.Models.Applies;

namespace Silas.ViewModels
{
    public class RightPanelViewModel
    {

        public string userRole { get; set; }
        public List<ApplyByCompany> companyApplyList { get; set; }

        public List<ApplyByStudent> studentApplyList { get; set; }


    }
}
