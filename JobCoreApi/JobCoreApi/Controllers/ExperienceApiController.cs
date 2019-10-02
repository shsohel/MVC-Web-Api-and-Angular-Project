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
    [Route("api/Experience")]
    [ApiController]
    public class ExperienceApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Experience> _repository;

        public ExperienceApiController(IDataAccessRepository<Experience> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetExperience")]
        public IActionResult GetExperience()
        {
            IEnumerable<Experience> experiences = _repository.GetAll();
            return Ok(experiences);
        }

        [HttpGet(Name = "GetExperiences")]
        [Route("GetExperienceById/{experiencesId}")]
        public IActionResult GetExperienceById(long experiencesId)
        {
            Experience experiences = _repository.Get(experiencesId);
            if (experiences == null)
            {
                return NotFound("Experience record Not Found !!!");
            }
            return Ok(experiences);
        }

        [HttpPost]
        [Route("InsertExperience")]
        public IActionResult PostExperience([FromBody] Experience experiences)
        {
            if (experiences == null)
            {
                return BadRequest("Experience is null!!!!!");
            }
            _repository.Add(experiences);
            return CreatedAtRoute("GetExperiences", new { Id = experiences.ExperienceID }, experiences);
        }

        [HttpPut]
        [Route("UpdateExperience/{experiencesId}")]
        public IActionResult PutExperience(long experiencesId, [FromBody] Experience experiences)
        {
            if (experiences == null)
            {
                return BadRequest("Experience is null!!!!");
            }

            Experience applyJobsToUpdate = _repository.Get(experiencesId);
            if (applyJobsToUpdate == null)
            {
                return NotFound("Experience Record Not Found");
            }
            _repository.Update(applyJobsToUpdate, experiences);
            return CreatedAtRoute("GetExperiences", new { Id = experiences.ExperienceID }, experiences);
        }

        [HttpPut]
        [Route("DeleteExperience/{experiencesId}")]
        public IActionResult DeleteExperience(long experiencesId)
        {
            Experience experiences = _repository.Get(experiencesId);
            if (experiences == null)
            {
                return NotFound("Experience Record not Found!!!!");
            }
            _repository.Delete(experiences);
            return GetExperience();
        }
    }
}