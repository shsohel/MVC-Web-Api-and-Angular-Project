using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models.Repository
{
    public class DARSkill : IDataAccessRepository<Skill, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {
            var skill = db.Skills.Find(id);
            if (skill != null)
            {
                db.Skills.Remove(skill);
                db.SaveChanges();
            }
        }

        public IEnumerable<Skill> Get()
        {
            return db.Skills.ToList();
        }

        public Skill Get(int id)
        {
            return db.Skills.Find(id);
        }

        public void Post(Skill entity)
        {
            db.Skills.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Skill entity)
        {
            var skill = db.Skills.Find(id);
            if (skill != null)
            {

                skill.SkillName = entity.SkillName;
                skill.PersonalDetailID = entity.PersonalDetailID;

                db.SaveChanges();
            }
        }
    }
}