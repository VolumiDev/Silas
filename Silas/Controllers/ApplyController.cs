using Microsoft.AspNetCore.Mvc;
using Silas.Models.Companies;
using Silas.Models.Courses;
using Silas.Models.Offers;
using Silas.Models.Student;
using Silas.ViewModels;
using System.Reflection;

namespace Silas.Controllers
{
    public class ApplyController : Controller
    {

        private readonly StudentService _studentService;
        private readonly OfferService _offerService;
        private readonly CompanyService _companyService;
        private readonly CourseService _courseService;

        public ApplyController(StudentService studentService, OfferService offerService, CourseService courseService, CompanyService companyService)
        {
            _studentService = studentService;
            _offerService = offerService;
            _courseService = courseService;
            this._companyService = companyService;
        }



        [HttpPost]
        public async Task<IActionResult> AddApply([FromBody] StudentOfferAplicationViewModel content)
        {
            var response = await _studentService.AddStudentApply(content);

            if (response)
            {
                return Json(new { success = true, message = "Inserción exitosa" });
            }
            else
            {
                return Json(new { success = false, message = "Error en la inserción" });
            }
        }
    }
}
