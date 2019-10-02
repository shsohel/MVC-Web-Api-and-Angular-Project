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
    [Route("api/JobList")]
    [ApiController]
    public class JobListApiController : ControllerBase
    {
        private readonly IDataAccessRepository<JobList> _repository;

        public JobListApiController(IDataAccessRepository<JobList> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetJobList")]
        public IActionResult GetJobList()
        {
            IEnumerable<JobList> jobLists = _repository.GetAll();
            return Ok(jobLists);
        }

        [HttpGet(Name= "GetJobLists")]
        [Route("GetJobListById/{jobId}")]
        public IActionResult GetJobListById(long jobId)
        {
            JobList jobList = _repository.Get(jobId);
            if (jobList == null)
            {
                return NotFound("Job List record Not Found !!!");
            }
            return Ok(jobList);
        }

        [HttpPost]
        [Route("InsertJobList")]
        public IActionResult PostJobList([FromBody] JobList jobList)
        {
            if (jobList == null)
            {
                return BadRequest("Job List is null!!!!!");
            }
            _repository.Add(jobList);
            return CreatedAtRoute("GetJobLists", new { Id = jobList.JobListID }, jobList);
        }

        [HttpPut]
        [Route("UpdateJobList/{jobId}")]
        public IActionResult PutJobList(long jobId, [FromBody] JobList jobList)
        {
            if (jobList == null)
            {
                return BadRequest("Job List is null!!!!");
            }

            JobList jobListToUpdate = _repository.Get(jobId);
            if (jobListToUpdate == null)
            {
                return NotFound("Job List Record Not Found");
            }
            _repository.Update(jobListToUpdate, jobList);
            return CreatedAtRoute("GetJobLists", new { Id = jobList.JobListID }, jobList);
        }

        [HttpPut]
        [Route("DeleteJobList/{jobId}")]
        public IActionResult DeleteJobList(long jobId)
        {
            JobList jobList = _repository.Get(jobId);
            if (jobList == null)
            {
                return NotFound("Job List Record not Found!!!!");
            }
            _repository.Delete(jobList);
            return GetJobList();
        }

    }

}