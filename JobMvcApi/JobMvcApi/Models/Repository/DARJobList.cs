using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Practices.Unity;
using System.Web;

namespace JobMvcApi.Models.Repository
{
    public class DARJobList : IDataAccessRepository<JobList, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {
            var joblist = db.JobLists.Find(id);
            if (joblist != null)
            {
                db.JobLists.Remove(joblist);
                db.SaveChanges();
            }
        }

        public IEnumerable<JobList> Get()
        {
            return db.JobLists.ToList();

        }

        public JobList Get(int id)
        {
            return db.JobLists.Find(id);
        }

        public void Post(JobList entity)
        {
            db.JobLists.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, JobList entity)
        {
            var job = db.JobLists.Find(id);
            if (job != null)
            {
                job.EmployerID = entity.EmployerID;
                job.Position = entity.Position;
                job.NumberofPost = entity.NumberofPost;
                job.SalaryScale = entity.SalaryScale;
                job.AgeLimit = entity.AgeLimit;
                job.EducationRequirement = entity.EducationRequirement;
                job.LastDateofApplication = entity.LastDateofApplication;
                job.IsApprove = entity.IsApprove;
                db.SaveChanges();
            }
        }
    }
}