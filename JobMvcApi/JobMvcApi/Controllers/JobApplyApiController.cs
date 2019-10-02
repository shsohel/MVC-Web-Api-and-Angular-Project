using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq.Expressions;

using JobMvcApi.Models;
using JobMvcApi.Models.Repository;
using System.Web.Http.Description;


namespace JobMvcApi.Controllers
{
    [RoutePrefix("api/ApplyJob")]

    public class JobApplyApiController : ApiController
    {
        private IDataAccessRepository<ApplyJob, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        private ApplicationDbContext db = new ApplicationDbContext();

        public JobApplyApiController(IDataAccessRepository<ApplyJob, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetApplicationList", Name = "GetJobApply")]
        public IEnumerable<ApplyJob> GetApplicationList()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetApplicantListById/{applyjobId}")]
        public IHttpActionResult GetApplicantListById(int applyjobId)
        {
            return Ok(_repository.Get(applyjobId));
        }

        [HttpPost]
        [Route("ApplyJobInsert")]
        public IHttpActionResult PostApplyJob(ApplyJob applyJob)
        {


            var jobapplynow = db.JobLists.Where(x => x.JobListID == applyJob.JobListID).SingleOrDefault();

            var persondetails = db.ApplyJobs.Where(x => x.PersonalDetailID == applyJob.PersonalDetailID).SingleOrDefault(x=>x.JobListID==applyJob.JobListID);
             
            if (persondetails == null && jobapplynow.LastDateofApplication>=DateTime.Now)
            {
                _repository.Post(applyJob);

            }

            return Ok(persondetails);
        }


        [HttpPut]
        [Route("ApplyJobUpdate/{applyjobId}")]
        public IHttpActionResult UpdateApplyJob(int applyjobId, ApplyJob  applyJob)
        {
            _repository.Put(applyjobId, applyJob);
            return CreatedAtRoute("GetJobApply", new { Id = applyJob.ApplyJobID }, applyJob);
        }




        [HttpDelete]
        [Route("CancelApplyJob/{applyjobId}")]
        public IHttpActionResult CancelApplyJob(int applyjobId, ApplyJob applyJob)
        {
            _repository.Delete(applyjobId);
            return CreatedAtRoute("GetJobApply", new { Id = applyJob.ApplyJobID }, applyJob);

        }
    }
}
