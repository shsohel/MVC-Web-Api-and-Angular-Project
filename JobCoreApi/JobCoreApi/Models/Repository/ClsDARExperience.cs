using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JobCoreApi.Data;

namespace JobCoreApi.Models.Repository
{
    public class ClsDARExperience : IDataAccessRepository<Experience>
    {
        readonly ApplicationDbContext _dbContext;
        public ClsDARExperience(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Add(Experience entity)
        {
            _dbContext.Experiences.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Experience entity)
        {
            _dbContext.Experiences.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Experience Get(long Id)
        {
            return _dbContext.Experiences.FirstOrDefault(e => e.ExperienceID == Id);
        }

        public IEnumerable<Experience> GetAll()
        {
            return _dbContext.Experiences.ToList();
        }

        public void Update(Experience dbEntity, Experience entity)
        {
            dbEntity.CompanyName = entity.CompanyName;
            dbEntity.CompnayBusiness = entity.CompnayBusiness;
            dbEntity.CompanyLocation = entity.CompanyLocation;
            dbEntity.Designation = entity.Designation;
            dbEntity.Department = entity.Department;
            dbEntity.Responsibilities = entity.Responsibilities;
            dbEntity.StartDate = entity.StartDate;
            dbEntity.EndDate = entity.EndDate;
            dbEntity.IsContinue = entity.IsContinue;
            dbEntity.PersonalDetailID = entity.PersonalDetailID;

            _dbContext.SaveChanges();
        }
    }
}
