using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using JobCoreApi.Data;

namespace JobCoreApi.Models.Repository
{
    public class ClsDARAddress : IDataAccessRepository<Address>
    {
        readonly ApplicationDbContext _dbContext;
        public ClsDARAddress(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void Add(Address entity)
        {
            _dbContext.Addresses.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Address entity)
        {
            _dbContext.Addresses.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Address Get(long Id)
        {
            return _dbContext.Addresses.FirstOrDefault(e => e.AddressID == Id);
        }

        public IEnumerable<Address> GetAll()
        {
            return _dbContext.Addresses.ToList();
        }

        public void Update(Address dbEntity, Address entity)
        {
            dbEntity.PresentAddress = entity.PresentAddress;
            dbEntity.PermanentAddress = entity.PermanentAddress;
            dbEntity.PersonalDetailID = entity.PersonalDetailID;

            _dbContext.SaveChanges();
        }
    }
}

