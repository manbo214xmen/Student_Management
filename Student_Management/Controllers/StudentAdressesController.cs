﻿using Business_Logic_Layer.DTOs;
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
        public List<StudentAddressDTO> Get()
        {
            return _studentAddressService.Get();
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
        public StudentAddressDTO Get(int id)
        {
            return _studentAddressService.Get(id);

        }

        /// <summary>
        /// Add a new student address
        /// </summary>
        [HttpPost]
        public ActionResult Post(StudentAddressDTO studentAddress)
        {
            if (ModelState.IsValid)
            {
                _studentAddressService.Post(studentAddress);
                return NoContent();
            }
            return BadRequest();

        }

        /// <summary>
        /// Edit/Update a specific student address from database
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Put(int id, StudentAddressDTO studentAddress)
        {
            if (id != studentAddress.StudentAddressId)
            {
                return BadRequest();
            }

            if (_studentAddressService.Put(id, studentAddress))
            {
                return NoContent();
            }
            return BadRequest();
        }


        /// <summary>
        /// Delete a specific student address from database
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            if (_studentAddressService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();

        }
    }
}
