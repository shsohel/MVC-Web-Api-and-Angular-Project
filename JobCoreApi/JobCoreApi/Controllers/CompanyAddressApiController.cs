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
    [Route("api/CompanyAddress")]
    [ApiController]
    public class CompanyAddressApiController : ControllerBase
    {
        private readonly IDataAccessRepository<CompanyAddress> _repository;

        public CompanyAddressApiController(IDataAccessRepository<CompanyAddress> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetCompanyAddress")]
        public IActionResult GetCompanyAddress()
        {
            IEnumerable<CompanyAddress> companyAddresses = _repository.GetAll();
            return Ok(companyAddresses);
        }

        [HttpGet(Name = "GetCompanyAddresses")]
        [Route("GetCompanyAddressById/{companyAddressesId}")]
        public IActionResult GetCompanyAddressById(long companyAddressesId)
        {
            CompanyAddress companyAddresses = _repository.Get(companyAddressesId);
            if (companyAddresses == null)
            {
                return NotFound("CompanyAddress record Not Found !!!");
            }
            return Ok(companyAddresses);
        }

        [HttpPost]
        [Route("InsertCompanyAddress")]
        public IActionResult PostCompanyAddress([FromBody] CompanyAddress companyAddresses)
        {
            if (companyAddresses == null)
            {
                return BadRequest("CompanyAddress is null!!!!!");
            }
            _repository.Add(companyAddresses);
            return CreatedAtRoute("GetCompanyAddresses", new { Id = companyAddresses.CompanyAddressID }, companyAddresses);
        }

        [HttpPut]
        [Route("UpdateCompanyAddress/{companyAddressesId}")]
        public IActionResult PutCompanyAddress(long companyAddressesId, [FromBody] CompanyAddress companyAddresses)
        {
            if (companyAddresses == null)
            {
                return BadRequest("CompanyAddress is null!!!!");
            }

            CompanyAddress applyJobsToUpdate = _repository.Get(companyAddressesId);
            if (applyJobsToUpdate == null)
            {
                return NotFound("Apply Jobs Record Not Found");
            }
            _repository.Update(applyJobsToUpdate, companyAddresses);
            return CreatedAtRoute("GetCompanyAddresses", new { Id = companyAddresses.CompanyAddressID }, companyAddresses);
        }

        [HttpPut]
        [Route("DeleteCompanyAddress/{applyJobsId}")]
        public IActionResult DeleteCompanyAddress(long applyJobsId)
        {
            CompanyAddress companyAddresses = _repository.Get(applyJobsId);
            if (companyAddresses == null)
            {
                return NotFound("CompanyAddress Record not Found!!!!");
            }
            _repository.Delete(companyAddresses);
            return GetCompanyAddress();
        }
    }
}