using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobMvcApi.Models.Repository
{
    public class DAREmployer : IDataAccessRepository<Employer, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {
            var employer = db.Employers.Find(id);
            if (employer != null)
            {
                db.Employers.Remove(employer);
                db.SaveChanges();
            }
        }

        public IEnumerable<Employer> Get()
        {
            return db.Employers.ToList();
        }

        public Employer Get(int id)
        {
            return db.Employers.Find(id);
        }

        public void Post(Employer entity)
        {
            db.Employers.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Employer entity)
        {
            var employer = db.Employers.Find(id);
            if (employer != null)
            {
                employer.UserName = entity.UserName;
               // employer.UserId = entity.UserId;
                employer.CompanyName = entity.CompanyName;
                employer.Catageory = entity.Catageory;
                employer.BusinessDescription = entity.BusinessDescription;
                employer.WebsiteUrl = entity.WebsiteUrl;
                employer.PhoneNumber = entity.PhoneNumber;
                employer.TelePhone = entity.TelePhone;
                employer.Fax = entity.Fax;
                employer.Email = entity.Email;


                db.SaveChanges();
            }
        }
    }
}