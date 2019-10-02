using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using JobCoreApi.Models;
using JobCoreApi.Models.Repository;

namespace JobCoreApi.Controllers
{
    [Route("api/Address")]
    [ApiController]
    public class AddressApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Address> _repository;

        public AddressApiController(IDataAccessRepository<Address> r)
        {
            _repository = r;
        }

        [HttpGet(Name ="GetAddre")]
        [Route("GetAddress")]
        public IActionResult GetAddress()
        {
            IEnumerable<Address> addresses = _repository.GetAll();
            return Ok(addresses);
        }

        [HttpGet]
        [Route("GetAddressById/{addressId}")]
        public IActionResult GetAddressById(long addressId)
        {
            Address address = _repository.Get(addressId);
            if (address == null)
            {
                return NotFound("Address record Not Found !!!");
            }
            return Ok(address);
        }

        [HttpPost]
        [Route("InsertAddress")]
        public IActionResult PostAddress([FromBody] Address address)
        {
            if (address == null)
            {
                return BadRequest("Address is null!!!!!");
            }
            _repository.Add(address);
            return CreatedAtRoute("GetAddre", new { Id = address.AddressID }, address);
        }

        [HttpPut]
        [Route("UpdateAddress/{addressId}")]
        public IActionResult PutAddress(long addressId, [FromBody] Address address)
        {
            if (address == null)
            {
                return BadRequest("Address is null!!!!");
            }

            Address addressToUpdate = _repository.Get(addressId);
            if (addressToUpdate == null)
            {
                return NotFound("Job List Record Not Found");
            }
            _repository.Update(addressToUpdate, address);
            return CreatedAtRoute("GetAddre", new { Id = address.AddressID }, address);
        }

        [HttpPut]
        [Route("DeleteAddress/{addressId}")]
        public IActionResult DeleteAddress(long addressId)
        {
            Address address = _repository.Get(addressId);
            if (address == null)
            {
                return NotFound("Job List Record not Found!!!!");
            }
            _repository.Delete(address);
            return GetAddress();
        }
    }
}