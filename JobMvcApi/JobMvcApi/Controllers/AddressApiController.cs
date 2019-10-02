using JobMvcApi.Models;
using JobMvcApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobMvcApi.Controllers
{
    [RoutePrefix("api/Address")]
    public class AddressApiController : ApiController
    {
        private IDataAccessRepository<Address, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        public AddressApiController(IDataAccessRepository<Address, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetAddressList", Name = "GetAddress")]
        public IEnumerable<Address> GetAddressList()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetAddressListById/{addressId}")]
        public IHttpActionResult GetAddressListById(int addressId)
        {
            return Ok(_repository.Get(addressId));
        }

        [HttpPost]
        [Route("AddressInsert")]
        public IHttpActionResult PostAddress(Address address)
        {
            _repository.Post(address);
            return Ok(address);
        }



        [HttpPut]
        [Route("UpdateAddress/{addressId}")]
        public IHttpActionResult PutPerson(int addressId, Address address)
        {
            _repository.Put(addressId, address);
            return CreatedAtRoute("GetAddress", new { Id = address.AddressID }, address);
        }


        [HttpDelete]
        [Route("CancelAddress/{addressId}")]
        public IHttpActionResult CancelAddress(int addressId, Address address)
        {
            _repository.Delete(addressId);
            return CreatedAtRoute("GetAddress", new { Id = address.AddressID }, address);

        }
    }
}
