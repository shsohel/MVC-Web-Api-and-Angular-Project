using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using JobMvcApi.Models;
using Microsoft.Practices.Unity;

namespace JobMvcApi.Models.Repository
{
    public class DARApplyJob : IDataAccessRepository<ApplyJob, int>
    {

        [Dependency]
        public ApplicationDbContext db { get; set; }


        public void Delete(int id)
        {
            var jobApply = db.ApplyJobs.Find(id);
            if (jobApply != null)
            {
                db.ApplyJobs.Remove(jobApply);
                db.SaveChanges();
            }
        }

        public IEnumerable<ApplyJob> Get()
        {
            return db.ApplyJobs.ToList();
        }

        public ApplyJob Get(int id)
        {
            return db.ApplyJobs.Find(id);
        }

        public void Post(ApplyJob entity)
        {
                db.ApplyJobs.Add(entity);
                db.SaveChanges();
        }
        public void Put(int id, ApplyJob entity)
        {
            var jobApply = db.ApplyJobs.Find(id);
            if (jobApply != null)
            {
                jobApply.JobListID = entity.JobListID;
                jobApply.JobList = entity.JobList;
                jobApply.PersonalDetailID = entity.PersonalDetailID;
                db.SaveChanges();
            }
        }
    }
}