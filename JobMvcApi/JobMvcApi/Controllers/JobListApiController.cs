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




    [RoutePrefix("api/JobList")]
    public class JobListApiController : ApiController
    {
        private IDataAccessRepository<JobList, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        public JobListApiController(IDataAccessRepository<JobList, int> r)
        {
            _repository = r;
        }

        
    
        [HttpGet]
        [Route("GetJobList", Name = "GetJobLists")]
        public IEnumerable<JobList> GetJobList()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetJobListById/{jobId}")]
        public IHttpActionResult GetJobListById(int jobId)
        {
            return Ok(_repository.Get(jobId));
        }

        [HttpPost]
        [Route("InsertJobList")]
        public IHttpActionResult PostJob(JobList jobList)
        {
            _repository.Post(jobList);
            return Ok(jobList);
        }


        [HttpPut]
        [Route("UpdateJobList/{jobId}")]
        public IHttpActionResult PutJob(int jobId, JobList jobList)
        {
            _repository.Put(jobId, jobList);
            return CreatedAtRoute("GetJobLists", new { Id = jobList.JobListID }, jobList);
        }


        [HttpDelete]
        [Route("DeleteJobList/{jobId}")]
        public IHttpActionResult DeleteJob(int jobId, JobList jobList)
        {
            _repository.Delete(jobId);
            return CreatedAtRoute("GetJobLists", new { Id = jobList.JobListID }, jobList);
        }
    }
}
