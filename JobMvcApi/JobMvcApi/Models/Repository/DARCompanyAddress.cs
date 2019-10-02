using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models.Repository
{
    public class DARCompanyAddress : IDataAccessRepository<CompanyAddress, int>
    {

        [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {
            var companyAddress = db.CompanyAddresses.Find(id);
            if (companyAddress != null)
            {
                db.CompanyAddresses.Remove(companyAddress);
                db.SaveChanges();
            }
        }

        public IEnumerable<CompanyAddress> Get()
        {
            return db.CompanyAddresses.ToList();
        }

        public CompanyAddress Get(int id)
        {
            return db.CompanyAddresses.Find(id);
        }

        public void Post(CompanyAddress entity)
        {
            db.CompanyAddresses.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, CompanyAddress entity)
        {
            var companyAddress = db.CompanyAddresses.Find(id);
            if (companyAddress != null)
            {
                companyAddress.Country = entity.Country;
                companyAddress.District = entity.District;
                companyAddress.Thana = entity.Thana;
                companyAddress.AddressDetails = entity.AddressDetails;
                companyAddress.EmployerID = entity.EmployerID;


                db.SaveChanges();
            }
        }
    }
}