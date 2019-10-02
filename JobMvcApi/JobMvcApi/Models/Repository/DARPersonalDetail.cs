using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

namespace JobMvcApi.Models.Repository
{
    public class DARPersonalDetail : IDataAccessRepository<PersonalDetail, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {
            var personalDetail = db.PersonalDetails.Find(id);
            if (personalDetail != null)
            {
                db.PersonalDetails.Remove(personalDetail);
                db.SaveChanges();
            }
        }

        public IEnumerable<PersonalDetail> Get()
        {



            return db.PersonalDetails.ToList();
        }

        public PersonalDetail Get(int id)
        {

            return db.PersonalDetails.Find(id);
        }

        public void Post(PersonalDetail entity)
        {
            string Photo = null;
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files["Image"];
            //Create custom filename
            Photo = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            Photo = Photo + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + Photo);
            postedFile.SaveAs(filePath);

            db.PersonalDetails.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, PersonalDetail entity)
        {

            var personalDetail = db.PersonalDetails.Find(id);
            if (personalDetail != null)
            {                               
             //   personalDetail.UserId = entity.UserId;
                personalDetail.UserName = entity.UserName;
                personalDetail.FirstName = entity.FirstName;
                personalDetail.LastName = entity.LastName;
                personalDetail.FatherName = entity.FatherName;
                personalDetail.MotherName = entity.MotherName;
                personalDetail.NationalID = entity.NationalID;
                personalDetail.CellPhone = entity.CellPhone;
                personalDetail.DOB = entity.DOB;

                personalDetail.Email = entity.Email;
                personalDetail.Photo = entity.Photo;

                //string Photo = null;
                //var httpRequest = HttpContext.Current.Request;
                ////Upload Image
                //var postedFile = httpRequest.Files["Image"];
                ////Create custom filename
                //Photo = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
                //Photo = Photo + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                //var filePath = HttpContext.Current.Server.MapPath("~/Image/" + Photo);
                //postedFile.SaveAs(filePath);

                //entity.Photo = Photo;

                db.SaveChanges();
            }
        }
    }
}