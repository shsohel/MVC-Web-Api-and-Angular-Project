using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JobCoreApi.Data;
namespace JobCoreApi.Models.Repository
{
    public class ClsDARJobList : IDataAccessRepository<JobList>
    {
        readonly ApplicationDbContext _dbContext;
        public ClsDARJobList(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Add(JobList entity)
        {
            _dbContext.JobLists.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(JobList entity)
        {
            _dbContext.JobLists.Remove(entity);
            _dbContext.SaveChanges();
        }

        public JobList Get(long Id)
        {
            return _dbContext.JobLists.FirstOrDefault(e => e.JobListID == Id);
        }

        public IEnumerable<JobList> GetAll()
        {
           return _dbContext.JobLists.ToList();
        }

        public void Update(JobList dbEntity, JobList entity)
        {
            dbEntity.EmployerID = entity.EmployerID;
            dbEntity.Position = entity.Position;
            dbEntity.NumberofPost = entity.NumberofPost;
            dbEntity.SalaryScale = entity.SalaryScale;
            dbEntity.AgeLimit = entity.AgeLimit;
            dbEntity.EducationRequirement = entity.EducationRequirement;
            dbEntity.LastDateofApplication = entity.LastDateofApplication;
            dbEntity.IsApprove = entity.IsApprove;

            _dbContext.SaveChanges();
        }
    }
}
