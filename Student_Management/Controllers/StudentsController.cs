using Business_Logic_Layer;
using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {

        StudentService _studentService;
        public StudentsController(StudentService studentService)
        {
            this._studentService = studentService;
        }

        /// <summary>
        /// Get all students from database
        /// </summary>
        [HttpGet]
        public List<StudentDTO> Get()
        {
            return _studentService.Get();
        }

        //[HttpGet]
        //[Route("Filter")]
        //public List<StudentDTO> Get([FromQuery] string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        //{
        //    return studentService.GetFilterStudent(name, gradeId, sortType, sortField, pageNumber, pageSize);
        //}

        /// <summary>
        /// Get a specific student from database
        /// </summary>
        [HttpGet("{id}")]
        public StudentDTO Get(int id)
        {
            return _studentService.Get(id);

        }

        /// <summary>
        /// Add a new student
        /// </summary>
        [HttpPost]
        public ActionResult Post(StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                _studentService.Post(student);
                return NoContent();
            }
            return BadRequest();

        }

        /// <summary>
        /// Edit/Update a specific student from database
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Put(int id, StudentDTO student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            if (_studentService.Put(id, student))
            {
                return NoContent();
            }
            return BadRequest();
        }


        /// <summary>
        /// Delete a specific student from database
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            if (_studentService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();

        }
    }
}

