using Microsoft.AspNetCore.Mvc;
using Silas.Models.Admin;
using Silas.Models.Companies;
using Silas.Models.Student;
using Silas.ViewModels;

namespace Silas.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {

        private readonly CompanyService _companyService;
        private readonly StudentService _studentService;
        private readonly AdminService _adminService;

        public HeaderViewComponent(CompanyService companyService, StudentService studentService, AdminService adminService)
        {
            _companyService = companyService;
            _studentService = studentService;
            _adminService = adminService;
        }


        public async Task<IViewComponentResult> InvokeAsync(string userRole, string userName, int userId)
        {
            // Aquí puedes realizar lógica adicional o cargar datos si es necesario.
            // Por ejemplo, si deseas obtener datos adicionales según el userRole.
            // En este ejemplo, simplemente se pasa el userRole al componente.


            if (userRole == "company")
            {
                var model = new HeaderViewModel
                {
                    userRole = userRole,
                    userName = userName,
                    userId = userId
                };

               
                return View("Header", model);

            }
            else if (userRole == "student")
            {
                var model = new HeaderViewModel
                {
                    userRole = userRole,
                    userName = userName,
                    userId = userId
                };

                return View("Header", model);
            }
            else
            {

                var model = new HeaderViewModel
                {
                    userRole = userRole,
                    userName = userName,
                    userId = userId
                };

                return View("Header", model);

            }

        }

    }
}
