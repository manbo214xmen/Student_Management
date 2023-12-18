using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CourseService courseService;

        public CoursesController(CourseService courseService)
        {
            this.courseService = courseService;
        }

        /// <summary>
        /// Get all courses from the database.
        /// </summary>
        [HttpGet]
        public List<CourseDTO> Get()
        {
            return courseService.Get();
        }

        /// <summary>
        /// Get a specific course by ID from the database.
        /// </summary>
        [HttpGet("{id}")]
        public CourseDTO Get(int id)
        {
            return courseService.Get(id);
        }

        /// <summary>
        /// Add a new course.
        /// </summary>
        [HttpPost]
        public ActionResult Post(CourseDTO course)
        {
            if (ModelState.IsValid)
            {
                courseService.Post(course);
                return NoContent();
            }
            return BadRequest();
        }

        /// <summary>
        /// Edit/Update a specific course in the database.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Put(int id, CourseDTO course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            if (courseService.Put(id, course))
            {
                return NoContent();
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete a specific course from the database.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (courseService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
