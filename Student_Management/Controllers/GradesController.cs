using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public List<GradeDTO> Get()
        {
            return _gradeService.Get();
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
        public GradeDTO Get(int id)
        {
            return _gradeService.Get(id);
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
                return Ok("Grade created successfully");
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
            if (id != grade.GradeId)
            {
                return BadRequest();
            }
            try
            {
                _gradeService.Put(id, grade);
                return Ok("Grade updated successfully");
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
