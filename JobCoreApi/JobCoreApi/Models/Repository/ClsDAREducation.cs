using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JobCoreApi.Data;

namespace JobCoreApi.Models.Repository
{
    public class ClsDAREducation : IDataAccessRepository<Education>
    {
        readonly ApplicationDbContext _dbContext;
        public ClsDAREducation(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Add(Education entity)
        {
            _dbContext.Educations.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Education entity)
        {
            _dbContext.Educations.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Education Get(long Id)
        {
            return _dbContext.Educations.FirstOrDefault(e => e.EducationID == Id);
        }

        public IEnumerable<Education> GetAll()
        {
            return _dbContext.Educations.ToList();
        }

        public void Update(Education dbEntity, Education entity)
        {
            dbEntity.LevelOfEducation = entity.LevelOfEducation;
            dbEntity.CGPA = entity.CGPA;
            dbEntity.Scale = entity.Scale;
            dbEntity.DegreeTitle = entity.DegreeTitle;
            dbEntity.Group = entity.Group;
            dbEntity.Institute = entity.Institute;
            dbEntity.PassingYear = entity.PassingYear;
            dbEntity.Duration = entity.Duration;
            dbEntity.Achievement = entity.Achievement;
            dbEntity.PersonalDetailID = entity.PersonalDetailID;

            _dbContext.SaveChanges();
        }
    }
}
