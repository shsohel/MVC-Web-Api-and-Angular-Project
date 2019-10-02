using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//Add 

using JobMvcApi.Models;
using JobMvcApi.Models.Repository;
using System.Web.Http.Description;


namespace JobMvcApi.Controllers
{
    [RoutePrefix("api/CompanyAddress")]
    public class CompanyAddressApiController : ApiController
    {
        private IDataAccessRepository<CompanyAddress, int> _repository;
        public CompanyAddressApiController(IDataAccessRepository<CompanyAddress, int> r)
        {
            _repository = r;
        }
        [HttpGet]
        [Route("GetCompanyAddress", Name = "GetCompany")]
        public IEnumerable<CompanyAddress> GetCompanyAddress()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetCompanyAddressById/{CompanyAddressId}")]
        public IHttpActionResult GetCompanyAddressById(int CompanyAddressId)
        {
            return Ok(_repository.Get(CompanyAddressId));
        }

        [HttpPost]
        [Route("InsertCompanyAddress")]
        public IHttpActionResult PostCompanyAddress(CompanyAddress companyAddress)
        {
            _repository.Post(companyAddress);
            return Ok(companyAddress);
        }
        [HttpPut]
        [Route("UpdateCompanyAddress/{CompanyAddressId}")]
        public IHttpActionResult PutCompanyAddress(int CompanyAddressId, CompanyAddress companyAddress)
        {
            _repository.Put(CompanyAddressId, companyAddress);
            return CreatedAtRoute("GetCompany", new { Id = companyAddress.CompanyAddressID }, companyAddress);
        }


        [HttpDelete]
        [Route("DeleteCompanyAddress/{CompanyAddressId}")]
        public IHttpActionResult DeleteJob(int CompanyAddressId, CompanyAddress companyAddress)
        {
            _repository.Delete(CompanyAddressId);
            return CreatedAtRoute("GetCompany", new { Id = companyAddress.CompanyAddressID }, companyAddress);
        }
    }
}
