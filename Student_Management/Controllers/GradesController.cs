using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/xml")]
    public class GradesController : ControllerBase
    {
        GradeService _gradeService;
        public GradesController(GradeService gradeService)
        {
            this._gradeService = gradeService;
        }

        /// <summary>
        /// Get all grades from database
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            var grades = _gradeService.Get();
            return Ok(grades);
        }

        //[HttpGet]
        //[Route("Filter")]
        //public List<StudentDTO> Get([FromQuery] string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        //{
        //    return studentService.GetFilterStudent(name, gradeId, sortType, sortField, pageNumber, pageSize);
        //}

        /// <summary>
        /// Get a specific grade from database
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {           
            try
            {
                return Ok(_gradeService.Get(id));
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get a List Students from specific grade from database
        /// </summary>
        [HttpGet("GetListStudent/{id}")]
        public IActionResult GetStudentList(int id)
        {
            try
            {
                return Ok(_gradeService.GetStudentListByGradeId(id));
                
            }
            catch(ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Add a new grade
        /// </summary>
        [HttpPost]
        public ActionResult Post(GradeDTO grade)
        {
            try
            {
                _gradeService.Post(grade);
                return Created("Grade created successfully", grade);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return a 400 Bad Request with the error message
            }

        }

        /// <summary>
        /// Edit/Update a specific grade from database
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Put(int id, GradeDTO grade)
        {
            try
            {
                _gradeService.Put(id, grade);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return a 400 Bad Request with the error message
            }
        }


        /// <summary>
        /// Delete a specific grade from database
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            if (_gradeService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();

        }
    }
}
