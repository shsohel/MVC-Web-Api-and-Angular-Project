using JobMvcApi.Models;
using JobMvcApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobMvcApi.Controllers
{
    [RoutePrefix("api/PersonalDetail")]
    public class PersonalDetailApiController : ApiController
    {
        private IDataAccessRepository<PersonalDetail, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        private ApplicationDbContext db = new ApplicationDbContext();

        public PersonalDetailApiController(IDataAccessRepository<PersonalDetail, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetPersonalDetailList", Name = "GetPersonalDetail")]
        public IEnumerable<PersonalDetail> GetPersonalDetailList()
        {
            //var peson = new PersonalDetail();
           
            //var existingUser = db.Users.FirstOrDefault(u => u.UserName == peson.UserName);

            //if(peson == null)
            //{
            //    return vi
            //}

            return _repository.Get();
        }

        [HttpGet]
        [Route("GetPersonalDetailListById/{personalDetailId}")]
        public IHttpActionResult GetPersonalDetailListById(int personalDetailId)
        {


            return Ok(_repository.Get(personalDetailId));
        }

        [HttpPost]
        [Route("PersonalDetailInsert")]
        public IHttpActionResult PostPersonalDetail(PersonalDetail personalDetail)
        {
            _repository.Post(personalDetail);
            return Ok(personalDetail);
        }



        [HttpPut]
        [Route("PersonalUpdate/{personalDetailId}")]
        public IHttpActionResult PutPerson(int personalDetailId, PersonalDetail personalDetail)
        {
            _repository.Put(personalDetailId, personalDetail);
            return CreatedAtRoute("GetPersonalDetail", new { Id = personalDetail.PersonalDetailID }, personalDetail);
        }



        [HttpDelete]
        [Route("CancelPersonalDetail/{personalDetailId}")]
        public IHttpActionResult CancelPersonalDetail(int personalDetailId, PersonalDetail personalDetail)
        {
            _repository.Delete(personalDetailId);
            return CreatedAtRoute("GetPersonalDetail", new { Id = personalDetail.PersonalDetailID }, personalDetail);

        }







    }
}
