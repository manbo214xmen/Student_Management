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

        /// <summary>
        /// Get a specific student with all related information from database
        /// </summary>
        [HttpGet("details/{id}")]
        public IActionResult GetStudentWithDetailsById(int id)
        {
            var studentWithDetails = _studentService.GetStudentWithDetailsById(id);

            if (studentWithDetails == null)
            {
                return NotFound();
            }

            return Ok(studentWithDetails);
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
            try
            {
                _studentService.Post(student);
                return Ok("Student created successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return a 400 Bad Request with the error message
            }            
        }

        /// <summary>
        /// Edit/Update a specific student from database
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Put(int id, StudentDTO student)
        {
            //if (id != student.StudentId)
            //{
            //    return BadRequest("Invalid StudentId !!!");
            //}
            try
            {
                _studentService.Put(id, student);
                return Ok("Student updated successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return a 400 Bad Request with the error message
            }

            //if (_studentService.Put(id, student))
            //{
            //    return NoContent();
            //}
            //return BadRequest();
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

