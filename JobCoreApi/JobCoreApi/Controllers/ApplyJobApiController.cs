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
    [Route("api/ApplyJob")]
    [ApiController]
    public class ApplyJobApiController : ControllerBase
    {
        private readonly IDataAccessRepository<ApplyJob> _repository;

        public ApplyJobApiController(IDataAccessRepository<ApplyJob> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetApplyJob")]
        public IActionResult GetApplyJob()
        {
            IEnumerable<ApplyJob> applyJobs = _repository.GetAll();
            return Ok(applyJobs);
        }

        [HttpGet(Name = "GetApplyJob")]
        [Route("GetApplyJobById/{applyJobsId}")]
        public IActionResult GetApplyJobById(long applyJobsId)
        {
            ApplyJob applyJobs = _repository.Get(applyJobsId);
            if (applyJobs == null)
            {
                return NotFound("ApplyJob record Not Found !!!");
            }
            return Ok(applyJobs);
        }

        [HttpPost]
        [Route("InsertApplyJob")]
        public IActionResult PostApplyJob([FromBody] ApplyJob applyJobs)
        {
            if (applyJobs == null)
            {
                return BadRequest("ApplyJob is null!!!!!");
            }
            _repository.Add(applyJobs);
            return CreatedAtRoute("GetApplyJob", new { Id = applyJobs.ApplyJobID }, applyJobs);
        }

        [HttpPut]
        [Route("UpdateApplyJob/{applyJobsId}")]
        public IActionResult PutApplyJob(long applyJobsId, [FromBody] ApplyJob applyJobs)
        {
            if (applyJobs == null)
            {
                return BadRequest("Apply Jobs is null!!!!");
            }

            ApplyJob applyJobsToUpdate = _repository.Get(applyJobsId);
            if (applyJobsToUpdate == null)
            {
                return NotFound("Apply Jobs Record Not Found");
            }
            _repository.Update(applyJobsToUpdate, applyJobs);
            return CreatedAtRoute("GetApplyJob", new { Id = applyJobs.ApplyJobID }, applyJobs);
        }

        [HttpPut]
        [Route("DeleteApplyJob/{applyJobsId}")]
        public IActionResult DeleteApplyJob(long applyJobsId)
        {
            ApplyJob applyJobs = _repository.Get(applyJobsId);
            if (applyJobs == null)
            {
                return NotFound("ApplyJob Record not Found!!!!");
            }
            _repository.Delete(applyJobs);
            return GetApplyJob();
        }
    }
}