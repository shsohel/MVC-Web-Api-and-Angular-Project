using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models.Repository
{
    public class DARExperience : IDataAccessRepository<Experience, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {
            var experience = db.Experiences.Find(id);
            if (experience != null)
            {
                db.Experiences.Remove(experience);
                db.SaveChanges();
            }
        }

        public IEnumerable<Experience> Get()
        {
            return db.Experiences.ToList();
        }

        public Experience Get(int id)
        {
            return db.Experiences.Find(id);
        }

        public void Post(Experience entity)
        {
            db.Experiences.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Experience entity)
        {
            var experience = db.Experiences.Find(id);
            if (experience != null)
            {
                experience.CompanyName = entity.CompanyName;
                experience.CompnayBusiness = entity.CompnayBusiness;
                experience.CompanyLocation = entity.CompanyLocation;
                experience.Designation = entity.Designation;
                experience.Department = entity.Department;
                experience.Responsibilities = entity.Responsibilities;
                experience.StartDate = entity.StartDate;
                experience.EndDate = entity.EndDate;
                experience.IsContinue = entity.IsContinue;
                experience.PersonalDetailID = entity.PersonalDetailID;
                db.SaveChanges();
            }
        }
    }
}