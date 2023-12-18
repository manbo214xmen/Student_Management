using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using Microsoft.Extensions.Configuration;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly GradeService gradeService;

        public GradesController(GradeService gradeService)
        {
            this.gradeService = gradeService;
        }

        /// <summary>
        /// Get all grades from the database.
        /// </summary>
        [HttpGet]
        public List<GradeDTO> Get()
        {
            return gradeService.Get();
        }

        /// <summary>
        /// Get a specific grade by ID from the database.
        /// </summary>
        [HttpGet("{id}")]
        public GradeDTO Get(int id)
        {
            return gradeService.Get(id);
        }

        /// <summary>
        /// Add a new grade.
        /// </summary>
        [HttpPost]
        public ActionResult Post(GradeDTO grade)
        {
            if (ModelState.IsValid)
            {
                gradeService.Post(grade);
                return NoContent();
            }
            return BadRequest();
        }

        /// <summary>
        /// Edit/Update a specific grade in the database.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Put(int id, GradeDTO grade)
        {
            if (id != grade.GradeId)
            {
                return BadRequest();
            }

            if (gradeService.Put(id, grade))
            {
                return NoContent();
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete a specific grade from the database.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (gradeService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
