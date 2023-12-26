using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAddressesController : ControllerBase
    {
        StudentAddressService _studentAddressService;
        public StudentAddressesController(StudentAddressService studentAddressService)
        {
            this._studentAddressService = studentAddressService;
        }

        /// <summary>
        /// Get all student addresses from database
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            var students = _studentAddressService.Get();
            return Ok(students);
        }

        //[HttpGet]
        //[Route("Filter")]
        //public List<StudentDTO> Get([FromQuery] string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        //{
        //    return studentService.GetFilterStudent(name, gradeId, sortType, sortField, pageNumber, pageSize);
        //}

        /// <summary>
        /// Get a specific student address from database
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var studentAddress = _studentAddressService.Get(id);
            if (studentAddress == null)
            { //Custom Http status code
                return new ObjectResult("Invalid StudentAddressId !!! Address not found.")
                {
                    StatusCode = 4042
                };
            }
            return Ok(studentAddress);
        }

        /// <summary>
        /// Add a new student address
        /// </summary>
        [HttpPost]
        public ActionResult Post(StudentAddressDTO studentAddress)
        {
            try
            {
                _studentAddressService.Post(studentAddress);
                return Created("Student address created successfully", studentAddress);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return a 400 Bad Request with the error message
            }

        }

        /// <summary>
        /// Edit/Update a specific student address from database
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id, StudentAddressDTO studentAddress)
        {
            try
            {
                _studentAddressService.Put(id, studentAddress);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return a 400 Bad Request with the error message
            }
        }


        /// <summary>
        /// Delete a specific student address from database
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (_studentAddressService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();

        }
    }
}
