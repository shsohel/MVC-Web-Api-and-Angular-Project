using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models.Repository
{
    public class DARAddress : IDataAccessRepository<Address, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {
            var address = db.Addresses.Find(id);
            if (address != null)
            {
                db.Addresses.Remove(address);
                db.SaveChanges();
            }
        }

        public IEnumerable<Address> Get()
        {
            return db.Addresses.ToList();
        }

        public Address Get(int id)
        {
            return db.Addresses.Find(id);
        }

        public void Post(Address entity)
        {
            db.Addresses.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Address entity)
        {
            var address = db.Addresses.Find(id);
            if (address != null)
            {
                address.PresentAddress = entity.PresentAddress;
                address.PermanentAddress = entity.PermanentAddress;
                address.PersonalDetailID = entity.PersonalDetailID;
                db.SaveChanges();
            }
        }
    }
}