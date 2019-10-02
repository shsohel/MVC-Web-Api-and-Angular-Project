using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JobCoreApi.Data;

namespace JobCoreApi.Models.Repository
{
    public class ClsDARApplyJob : IDataAccessRepository<ApplyJob>
    {
        readonly ApplicationDbContext _dbContext;
        public ClsDARApplyJob(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Add(ApplyJob entity)
        {
            _dbContext.ApplyJobs.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(ApplyJob entity)
        {
            _dbContext.ApplyJobs.Remove(entity);
            _dbContext.SaveChanges();
        }

        public ApplyJob Get(long Id)
        {
            return _dbContext.ApplyJobs.FirstOrDefault(e => e.ApplyJobID == Id);
        }

        public IEnumerable<ApplyJob> GetAll()
        {
            return _dbContext.ApplyJobs.ToList();
        }

        public void Update(ApplyJob dbEntity, ApplyJob entity)
        {
            dbEntity.JobListID = entity.JobListID;
            dbEntity.JobList = entity.JobList;
            dbEntity.PersonalDetailID = entity.PersonalDetailID;

            _dbContext.SaveChanges();
        }
    }
}
