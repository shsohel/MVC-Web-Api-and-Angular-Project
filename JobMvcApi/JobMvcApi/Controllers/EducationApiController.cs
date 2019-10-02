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
    [RoutePrefix("api/Education")]
    public class EducationApiController : ApiController
    {
        private IDataAccessRepository<Education, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        public EducationApiController(IDataAccessRepository<Education, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetEducation", Name = "GetEducations")]
        public IEnumerable<Education> GetEducation()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetEducationtById/{educationId}")]
        public IHttpActionResult GetEducationById(int educationId)
        {
            return Ok(_repository.Get(educationId));
        }

        [HttpPost]
        [Route("InsertEducation")]
        public IHttpActionResult PostEducation(Education education)
        {
            _repository.Post(education);
            return Ok(education);
        }
        [HttpPut]
        [Route("UpdateEducation/{educationId}")]
        public IHttpActionResult PutEducation(int educationId, Education education)
        {
            _repository.Put(educationId, education);
            return CreatedAtRoute("GetEducations", new { Id = education.EducationID }, education);
        }


        [HttpDelete]
        [Route("DeleteEducation/{educationId}")]
        public IHttpActionResult DeleteEducation(int educationId, Education education)
        {
            _repository.Delete(educationId);
            return CreatedAtRoute("GetEducations", new { Id = education.EducationID }, education);
        }
    }
}
