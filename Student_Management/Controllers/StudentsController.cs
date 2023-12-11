using Business_Logic_Layer;
using Business_Logic_Layer.DTO;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {

        StudentService studentService;
        public StudentsController(StudentService studentService)
        {
            this.studentService = studentService;
        }


        [HttpGet]
        public List<StudentDTO> Get()
        {
            return studentService.Get();
        }

        //[HttpGet]
        //[Route("Filter")]
        //public List<StudentDTO> Get([FromQuery] string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        //{
        //    return studentService.GetFilterStudent(name, gradeId, sortType, sortField, pageNumber, pageSize);
        //}

        [HttpGet("{id}")]
        public StudentDTO Get(int id)
        {
            return studentService.Get(id);

        }


        [HttpPost]
        public ActionResult Post(StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                studentService.Post(student);
                return NoContent();
            }
            return BadRequest();

        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, StudentDTO student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            if (studentService.Put(id, student))
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            if (studentService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();

        }
    }
}

