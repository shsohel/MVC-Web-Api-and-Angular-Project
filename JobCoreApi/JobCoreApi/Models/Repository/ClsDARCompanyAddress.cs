using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JobCoreApi.Data;

namespace JobCoreApi.Models.Repository
{
    public class ClsDARCompanyAddress : IDataAccessRepository<CompanyAddress>
    {
        readonly ApplicationDbContext _dbContext;
        public ClsDARCompanyAddress(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Add(CompanyAddress entity)
        {
            _dbContext.CompanyAddresses.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(CompanyAddress entity)
        {
            _dbContext.CompanyAddresses.Remove(entity);
            _dbContext.SaveChanges();
        }

        public CompanyAddress Get(long Id)
        {
            return _dbContext.CompanyAddresses.FirstOrDefault(e => e.CompanyAddressID == Id);
        }

        public IEnumerable<CompanyAddress> GetAll()
        {
            return _dbContext.CompanyAddresses.ToList();
        }

        public void Update(CompanyAddress dbEntity, CompanyAddress entity)
        {
            dbEntity.Country = entity.Country;
            dbEntity.District = entity.District;
            dbEntity.Thana = entity.Thana;
            dbEntity.AddressDetails = entity.AddressDetails;
            dbEntity.EmployerID = entity.EmployerID;

            _dbContext.SaveChanges();
        }
    }
}
