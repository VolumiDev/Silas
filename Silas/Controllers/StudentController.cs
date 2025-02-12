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

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(Student student)
        {
            if (!ModelState.IsValid)
            {
                // Retorna un error o la vista con validaciones si hay datos no válidos
                return BadRequest(ModelState);
            }

            // Actualiza el estudiante en la base de datos mediante el servicio.
            bool updateResult = await _studentService.UpdateStudentAsync(student);
            if (!updateResult)
            {
                return StatusCode(500, "Error updating student profile.");
            }

            // Vuelve a cargar el perfil actualizado (usando el servicio para obtener los datos actualizados)
            var updatedStudent = await _studentService.GetStudentByIdAsync(student.IdUser);
            return PartialView("~/Views/NavButtons/ProfileStudent.cshtml", updatedStudent);
        }
    }
}
