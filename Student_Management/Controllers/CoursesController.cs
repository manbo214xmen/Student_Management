﻿using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        CourseService _courseService;
        public CoursesController(CourseService courseService)
        {
            this._courseService = courseService;
        }

        /// <summary>
        /// Get all courses from database
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            var courses = _courseService.Get();
            return Ok(courses);
        }

        /// <summary>
        /// To page and filter courses
        /// </summary>
        [HttpGet("filter")]
        public IActionResult Get(int page = 1, int pageSize = 3, string filter = "")
        {
            var courses = _courseService.PagingAndFilteringCourses(page, pageSize, filter);
            if (courses.Any())
            {
                return Ok(courses);
            }
            else
            {
                return NotFound("Not found: No results match your search string !!!");
            }
        }

        /// <summary>
        /// To get students by courseId
        /// </summary>
        [HttpGet("byCourse/{courseId}")]
        public IActionResult GetStudentsByCourseId(int courseId)
        {
            try
            {
                var students = _courseService.GetStudentsByCourseId(courseId);
                return Ok(students);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message); // Return a 400 Bad Request with the error message
            }
        }

        //[HttpGet]
        //[Route("Filter")]
        //public List<StudentDTO> Get([FromQuery] string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        //{
        //    return studentService.GetFilterStudent(name, gradeId, sortType, sortField, pageNumber, pageSize);
        //}

        /// <summary>
        /// Get a specific course from database
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var course = _courseService.Get(id);
            if (course == null)
            { //Custom Http status code
                return new ObjectResult("Invalid CourseId !!! Course not found.")
                {
                    StatusCode = 4044
                };
            }
            return Ok(course);
        }

        /// <summary>
        /// Add a new course
        /// </summary>
        [HttpPost]
        public ActionResult Post(CourseDTO course)
        {
            try
            {
                _courseService.Post(course);
                return Created("Course created successfully", course);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return a 400 Bad Request with the error message
            }
        }

        /// <summary>
        /// Edit/Update a specific course from database
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Put(int id, CourseDTO course)
        {

            try
            {
                _courseService.Put(id, course);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return a 400 Bad Request with the error message
            }
        }


        /// <summary>
        /// Delete a specific course from database
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            if (_courseService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();

        }
    }
}
