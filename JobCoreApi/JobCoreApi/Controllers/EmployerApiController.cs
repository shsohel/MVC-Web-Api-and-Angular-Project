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
    [Route("api/Employer")]
    [ApiController]
    public class EmployerApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Employer> _repository;

        public EmployerApiController(IDataAccessRepository<Employer> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetEmployer")]
        public IActionResult GetEmployer()
        {
            IEnumerable<Employer> employers = _repository.GetAll();
            return Ok(employers);
        }

        [HttpGet(Name = "GetEmployers")]
        [Route("GetEmployerById/{employerId}")]
        public IActionResult GetEmployerById(long employerId)
        {
            Employer employer = _repository.Get(employerId);
            if (employer == null)
            {
                return NotFound("Employer record Not Found !!!");
            }
            return Ok(employer);
        }

        [HttpPost]
        [Route("InsertEmployer")]
        public IActionResult PostEmployer([FromBody] Employer employer)
        {
            if (employer == null)
            {
                return BadRequest("Employer is null!!!!!");
            }
            _repository.Add(employer);
            return CreatedAtRoute("GetEmployers", new { Id = employer.EmployerID }, employer);
        }

        [HttpPut]
        [Route("UpdateEmployer/{employerId}")]
        public IActionResult PutEmployer(long employerId, [FromBody] Employer employer)
        {
            if (employer == null)
            {
                return BadRequest("Employer is null!!!!");
            }

            Employer employerToUpdate = _repository.Get(employerId);
            if (employerToUpdate == null)
            {
                return NotFound("Job List Record Not Found");
            }
            _repository.Update(employerToUpdate, employer);
            return CreatedAtRoute("GetEmployers", new { Id = employer.EmployerID }, employer);
        }

        [HttpPut]
        [Route("DeleteEmployer/{employerId}")]
        public IActionResult DeleteEmployer(long employerId)
        {
            Employer employer = _repository.Get(employerId);
            if (employer == null)
            {
                return NotFound("Employer Record not Found!!!!");
            }
            _repository.Delete(employer);
            return GetEmployer();
        }
    }
}