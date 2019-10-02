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
    [RoutePrefix("api/Employer")]
    public class EmployerApiController : ApiController
    {
        private IDataAccessRepository<Employer, int> _repository;


        public EmployerApiController(IDataAccessRepository<Employer, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetEmployer", Name = "GetEmployers")]
        public IEnumerable<Employer> GetEmployer()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetEmployerById/{employerId}")]
        public IHttpActionResult GetEmployerById(int employerId)
        {
            return Ok(_repository.Get(employerId));
        }

        [HttpPost]
        [Route("InsertEmployer")]
        public IHttpActionResult PostEmployer(Employer employer)
        {
            _repository.Post(employer);
            return Ok(employer);
        }
        [HttpPut]
        [Route("UpdateEmployer/{employerId}")]
        public IHttpActionResult PutEmployer(int employerId, Employer employer)
        {
            _repository.Put(employerId, employer);
            return CreatedAtRoute("GetEmployers", new { Id = employer.EmployerID }, employer);
        }


        [HttpDelete]
        [Route("DeleteEmployer/{employerId}")]
        public IHttpActionResult DeleteEmployer(int employerId, Employer employer)
        {
            _repository.Delete(employerId);
            return CreatedAtRoute("GetEmployers", new { Id = employer.EmployerID }, employer);
        }
    }
}
