using Microsoft.AspNetCore.Mvc;
using Silas.Models.Student;
using System.Threading.Tasks;

namespace Silas.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Details(int id)
        {
            //GET DETALLES DE ALUMNO
            var student = await _studentService.GetStudentByIdAsync(id);
            return View(student);
        }
    }
}
