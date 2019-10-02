using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models.Repository
{
    public class DAREducation : IDataAccessRepository<Education, int>
    {

        [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {
            var education = db.Educations.Find(id);
            if (education != null)
            {
                db.Educations.Remove(education);
                db.SaveChanges();
            }
        }

        public IEnumerable<Education> Get()
        {
            return db.Educations.ToList();
        }

        public Education Get(int id)
        {
            return db.Educations.Find(id);
        }

        public void Post(Education entity)
        {
            db.Educations.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Education entity)
        {
            var education = db.Educations.Find(id);
            if (education != null)
            {

                education.LevelOfEducation = entity.LevelOfEducation;
                education.CGPA = entity.CGPA;
                education.Scale = entity.Scale;
                education.DegreeTitle = entity.DegreeTitle;
                education.Group = entity.Group;
                education.Institute = entity.Institute;
                education.PassingYear = entity.PassingYear;
                education.Duration = entity.Duration;
                education.Achievement = entity.Achievement;
                education.PersonalDetailID = entity.PersonalDetailID;

                db.SaveChanges();
            }
        }
    }
}