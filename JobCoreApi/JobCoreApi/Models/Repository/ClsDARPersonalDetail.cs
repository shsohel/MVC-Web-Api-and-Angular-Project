using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JobCoreApi.Data;

namespace JobCoreApi.Models.Repository
{
    public class ClsDARPersonalDetail : IDataAccessRepository<PersonalDetail>
    {
        readonly ApplicationDbContext _dbContext;
        public ClsDARPersonalDetail(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Add(PersonalDetail entity)
        {
            _dbContext.PersonalDetails.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(PersonalDetail entity)
        {
            _dbContext.PersonalDetails.Remove(entity);
            _dbContext.SaveChanges();
        }

        public PersonalDetail Get(long Id)
        {
            return _dbContext.PersonalDetails.FirstOrDefault(e => e.PersonalDetailID == Id);
        }

        public IEnumerable<PersonalDetail> GetAll()
        {
            return _dbContext.PersonalDetails.ToList();
        }

        public void Update(PersonalDetail dbEntity, PersonalDetail entity)
        {
            dbEntity.UserId = entity.UserId;
            dbEntity.UserName = entity.UserName;
            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;
            dbEntity.FatherName = entity.FatherName;
            dbEntity.MotherName = entity.MotherName;
            dbEntity.NationalID = entity.NationalID;
            dbEntity.CellPhone = entity.CellPhone;
            dbEntity.Email = entity.Email;

            _dbContext.SaveChanges();
        }
    }
}
