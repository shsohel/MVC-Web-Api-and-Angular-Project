using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JobCoreApi.Data;

namespace JobCoreApi.Models.Repository
{
    public class ClsDAREmployer : IDataAccessRepository<Employer>
    {
        readonly ApplicationDbContext _dbContext;
        public ClsDAREmployer(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Add(Employer entity)
        {
            _dbContext.Employers.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Employer entity)
        {
            _dbContext.Employers.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Employer Get(long Id)
        {
            return _dbContext.Employers.FirstOrDefault(e => e.EmployerID == Id);
        }

        public IEnumerable<Employer> GetAll()
        {
            return _dbContext.Employers.ToList();
        }

        public void Update(Employer dbEntity, Employer entity)
        {
            dbEntity.UserName = entity.UserName;
            dbEntity.UserId = entity.UserId;
            dbEntity.CompanyName = entity.CompanyName;
            dbEntity.Catageory = entity.Catageory;
            dbEntity.BusinessDescription = entity.BusinessDescription;
            dbEntity.WebsiteUrl = entity.WebsiteUrl;
            dbEntity.PhoneNumber = entity.PhoneNumber;
            dbEntity.TelePhone = entity.TelePhone;
            dbEntity.Fax = entity.Fax;
            dbEntity.Email = entity.Email;

            _dbContext.SaveChanges();
        }
    }
}
