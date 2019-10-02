using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models.Repository
{
    public class DARTraining : IDataAccessRepository<Training, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {
            var training = db.Trainings.Find(id);
            if (training != null)
            {
                db.Trainings.Remove(training);
                db.SaveChanges();
            }
        }

        public IEnumerable<Training> Get()
        {
            return db.Trainings.ToList();
        }

        public Training Get(int id)
        {
            return db.Trainings.Find(id);
        }

        public void Post(Training entity)
        {
            db.Trainings.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Training entity)
        {
            var training = db.Trainings.Find(id);
            if (training != null)
            {   training.Title = entity.Title;
                training.Topics = entity.Topics;
                training.Institute = entity.Institute;
                training.Location = entity.Location;
                training.Country = entity.Country;
                training.TrainingYear = entity.TrainingYear;
                training.Duration = entity.Duration;
                training.PersonalDetailID = entity.PersonalDetailID;


                db.SaveChanges();
            }
        }
    }
}