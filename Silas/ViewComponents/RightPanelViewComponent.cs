using Microsoft.AspNetCore.Mvc;
using Silas.Models;
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

        public RightPanelViewComponent(CompanyService companyService, StudentService studentService)
		{
			_companyService = companyService;
            _studentService = studentService;
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
                    userRole = "userRole",
                    studentApplyList = appliesList.Applies
                };
                return View("RightPanel", model);
            }
            else
            {

                var model = new RightPanelViewModel
                {
                    userRole = "userRole",
                    companyApplyList = []
                };
                //ESTE ES EL ADMIN
                return View("RightPanel", model);

            }

        }

    }
}
