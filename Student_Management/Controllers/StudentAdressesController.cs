using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly StudentAddressService studentAddressService;

        public AddressesController(StudentAddressService studentAddressService)
        {
            this.studentAddressService = studentAddressService;
        }

        [HttpGet]
        public List<StudentAddressDTO> Get()
        {
            return studentAddressService.Get();
        }

        [HttpGet("{id}")]
        public StudentAddressDTO Get(int id)
        {
            return studentAddressService.Get(id);
        }

        [HttpPost]
        public ActionResult Post(StudentAddressDTO studentAddress)
        {
            if (ModelState.IsValid)
            {
                studentAddressService.Post(studentAddress);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, StudentAddressDTO studentAddress)
        {
            if (id != studentAddress.StudentAdressId)
            {
                return BadRequest();
            }

            if (studentAddressService.Put(id, studentAddress))
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (studentAddressService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
