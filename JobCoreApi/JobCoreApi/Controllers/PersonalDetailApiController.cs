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
    [Route("api/PersonalDetail")]
    [ApiController]
    public class PersonalDetailApiController : ControllerBase
    {
        private readonly IDataAccessRepository<PersonalDetail> _repository;

        public PersonalDetailApiController(IDataAccessRepository<PersonalDetail> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetPersonalDetail")]
        public IActionResult GetPersonalDetail()
        {
            IEnumerable<PersonalDetail> personalDetails = _repository.GetAll();
            return Ok(personalDetails);
        }

        [HttpGet(Name = "GetPersonalDetails")]
        [Route("GetPersonalDetailById/{personalDetailsId}")]
        public IActionResult GetPersonalDetailById(long personalDetailsId)
        {
            PersonalDetail personalDetails = _repository.Get(personalDetailsId);
            if (personalDetails == null)
            {
                return NotFound("Personal Detail record Not Found !!!");
            }
            return Ok(personalDetails);
        }

        [HttpPost]
        [Route("InsertPersonalDetail")]
        public IActionResult PostPersonalDetail([FromBody] PersonalDetail personalDetails)
        {
            if (personalDetails == null)
            {
                return BadRequest("PersonalDetail is null!!!!!");
            }
            _repository.Add(personalDetails);
            return CreatedAtRoute("GetPersonalDetails", new { Id = personalDetails.PersonalDetailID }, personalDetails);
        }

        [HttpPut]
        [Route("UpdatePersonalDetail/{personalDetailsId}")]
        public IActionResult PutPersonalDetail(long personalDetailsId, [FromBody] PersonalDetail personalDetails)
        {
            if (personalDetails == null)
            {
                return BadRequest("Personal Detail is null!!!!");
            }

            PersonalDetail personalDetailsToUpdate = _repository.Get(personalDetailsId);
            if (personalDetailsToUpdate == null)
            {
                return NotFound("Personal Detail Record Not Found");
            }
            _repository.Update(personalDetailsToUpdate, personalDetails);
            return CreatedAtRoute("GetPersonalDetails", new { Id = personalDetails.PersonalDetailID }, personalDetails);
        }

        [HttpPut]
        [Route("DeletePersonalDetail/{personalDetailsId}")]
        public IActionResult DeletePersonalDetail(long personalDetailsId)
        {
            PersonalDetail personalDetails = _repository.Get(personalDetailsId);
            if (personalDetails == null)
            {
                return NotFound("Personal Detail Record not Found!!!!");
            }
            _repository.Delete(personalDetails);
            return GetPersonalDetail();
        }
    }
}