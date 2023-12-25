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

        /// <summary>
        /// To show which courses that a specific student enroll in
        /// </summary>
        [HttpGet("{studentId}/courses")]
        public IActionResult GetEnrolledCourses(int studentId)
        {
            var enrolledCourses = _studentService.GetEnrolledCoursesByStudentId(studentId);
            return Ok(enrolledCourses);
        }

        /// <summary>
        /// To assign a student to a course
        /// </summary>
        [HttpPost("{studentId}/assignCourse/{courseId}")]
        public IActionResult AssignCourse(int studentId, int courseId)
        {
            try
            {
                _studentService.AssignCourse(studentId, courseId);
                return Ok("Assignment successful");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// To page and filter students
        /// </summary>
        [HttpGet("filter")]
        public IActionResult Get(int page = 1, int pageSize = 3, string filter = "")
        {
            var students = _studentService.PagingAndFilteringStudents(page, pageSize, filter);
            return Ok(students);
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
        public IActionResult Get(int id)
        {
            var student = _studentService.Get(id);
            if (student == null)
            { //Custom Http status code
                return new ObjectResult("Invalid StudentId !!! Student not found.")
                {
                    StatusCode = 4041
                };
            }
            return Ok(student);
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

