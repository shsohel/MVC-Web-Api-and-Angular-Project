using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JobCoreApi.Data;

namespace JobCoreApi.Models.Repository
{
    public class ClsDARSkill : IDataAccessRepository<Skill>
    {
        readonly ApplicationDbContext _dbContext;
        public ClsDARSkill(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Add(Skill entity)
        {
            _dbContext.Skills.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Skill entity)
        {
            _dbContext.Skills.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Skill Get(long Id)
        {
            return _dbContext.Skills.FirstOrDefault(e => e.SkillID == Id);
        }

        public IEnumerable<Skill> GetAll()
        {
            return _dbContext.Skills.ToList();
        }

        public void Update(Skill dbEntity, Skill entity)
        {
            dbEntity.SkillName = entity.SkillName;
            dbEntity.PersonalDetailID = entity.PersonalDetailID;
            _dbContext.SaveChanges();
        }
    }
}
