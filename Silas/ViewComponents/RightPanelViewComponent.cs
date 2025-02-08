using Microsoft.AspNetCore.Mvc;
using Silas.Models;
using Silas.Models.Admin;
using Silas.Models.Companies;
using Silas.Models.Student;
using Silas.ViewModels;
using System.Reflection;


namespace Silas.ViewComponents
{

    public class  RightPanelViewComponent: ViewComponent
    {

        
		private readonly CompanyService _companyService;
		private readonly StudentService _studentService;
        private readonly AdminService _adminService;

        public RightPanelViewComponent(CompanyService companyService, StudentService studentService, AdminService adminService)
		{
			_companyService = companyService;
            _studentService = studentService;
            _adminService = adminService;
        }


		public async Task<IViewComponentResult> InvokeAsync(string userRole, int userId)
        {
            // Aquí puedes realizar lógica adicional o cargar datos si es necesario.
            // Por ejemplo, si deseas obtener datos adicionales según el userRole.
            // En este ejemplo, simplemente se pasa el userRole al componente.


            if (userRole == "company"){
                var appliesList = await _companyService.ListAplliesByCompanyId(userId);

                var model = new RightPanelViewModel
			    {
				    userRole = userRole,
				    companyApplyList = appliesList
			    };
			    return View("RightPanel", model);

            }
            else if (userRole == "student")
            {
                var appliesList = await _studentService.ListAplliesByStudentId(userId);
                var model = new RightPanelViewModel
                {
                    userRole = userRole,
                    studentApplyList = appliesList.Applies
                };
                return View("RightPanel", model);
            }
            else
            {
                var appliesList = await _adminService.GetAppliesToAdmin();
                var model = new RightPanelViewModel
                {
                    userRole = "admin",
                    adminApplyList = appliesList.Applies
                };


                //ESTE ES EL ADMIN
                return View("RightPanel", model);

            }

        }

    }
}
