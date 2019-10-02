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
    [RoutePrefix("api/Experience")]
    public class ExperienceApiController : ApiController
    {
        private IDataAccessRepository<Experience, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        public ExperienceApiController(IDataAccessRepository<Experience, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetExperience", Name = "GetExperiences")]
        public IEnumerable<Experience> GetExperience()
        {

            return _repository.Get();
        }

        [HttpGet]
        [Route("GetExperienceById/{experienceId}")]
        public IHttpActionResult GetExperienceById(int experienceId)
        {
            return Ok(_repository.Get(experienceId));
        }

        [HttpPost]
        [Route("InsertExperienceList")]
        public IHttpActionResult PostExperience(Experience experience)
        {
            _repository.Post(experience);
            return Ok(experience);
        }
        [HttpPut]
        [Route("UpdateExperience/{experienceId}")]
        public IHttpActionResult PutExperience(int experienceId, Experience experience)
        {
            _repository.Put(experienceId, experience);
            return CreatedAtRoute("GetExperiences", new { Id = experience.ExperienceID }, experience);
        }


        [HttpDelete]
        [Route("DeleteJobList/{experienceId}")]
        public IHttpActionResult DeleteExperience(int experienceId, Experience experience)
        {
            _repository.Delete(experienceId);
            return CreatedAtRoute("GetExperiences", new { Id = experience.ExperienceID }, experience);
        }
    }
}
