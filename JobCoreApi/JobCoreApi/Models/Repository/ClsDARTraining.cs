using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JobCoreApi.Data;

namespace JobCoreApi.Models.Repository
{
    public class ClsDARTraining : IDataAccessRepository<Training>
    {
        readonly ApplicationDbContext _dbContext;
        public ClsDARTraining(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Add(Training entity)
        {
            _dbContext.Trainings.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Training entity)
        {
            _dbContext.Trainings.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Training Get(long Id)
        {
            return _dbContext.Trainings.FirstOrDefault(e => e.TrainingID == Id);
        }

        public IEnumerable<Training> GetAll()
        {
            return _dbContext.Trainings.ToList();
        }

        public void Update(Training dbEntity, Training entity)
        {
            dbEntity.Title = entity.Title;
            dbEntity.Topics = entity.Topics;
            dbEntity.Institute = entity.Institute;
            dbEntity.Location = entity.Location;
            dbEntity.Country = entity.Country;
            dbEntity.TrainingYear = entity.TrainingYear;
            dbEntity.Duration = entity.Duration;
            dbEntity.PersonalDetailID = entity.PersonalDetailID;
            _dbContext.SaveChanges();
        }
    }
}
