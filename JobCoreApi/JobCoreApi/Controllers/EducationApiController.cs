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
    [Route("api/Education")]
    [ApiController]
    public class EducationApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Education> _repository;

        public EducationApiController(IDataAccessRepository<Education> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetEducation")]
        public IActionResult GetEducation()
        {
            IEnumerable<Education> educations = _repository.GetAll();
            return Ok(educations);
        }

        [HttpGet(Name = "GetEducations")]
        [Route("GetEducationById/{educationsId}")]
        public IActionResult GetEducationById(long educationsId)
        {
            Education educations = _repository.Get(educationsId);
            if (educations == null)
            {
                return NotFound("Education record Not Found !!!");
            }
            return Ok(educations);
        }

        [HttpPost]
        [Route("InsertEducation")]
        public IActionResult PostEducation([FromBody] Education educations)
        {
            if (educations == null)
            {
                return BadRequest("Education is null!!!!!");
            }
            _repository.Add(educations);
            return CreatedAtRoute("GetEducations", new { Id = educations.EducationID }, educations);
        }

        [HttpPut]
        [Route("UpdateEducation/{educationsId}")]
        public IActionResult PutEducation(long educationsId, [FromBody] Education educations)
        {
            if (educations == null)
            {
                return BadRequest("Education is null!!!!");
            }

            Education educationsToUpdate = _repository.Get(educationsId);
            if (educationsToUpdate == null)
            {
                return NotFound("Education Record Not Found");
            }
            _repository.Update(educationsToUpdate, educations);
            return CreatedAtRoute("GetEducations", new { Id = educations.EducationID }, educations);
        }

        [HttpPut]
        [Route("DeleteEducation/{educationsId}")]
        public IActionResult DeleteEducation(long educationsId)
        {
            Education educations = _repository.Get(educationsId);
            if (educations == null)
            {
                return NotFound("Education Record not Found!!!!");
            }
            _repository.Delete(educations);
            return GetEducation();
        }
    }
}