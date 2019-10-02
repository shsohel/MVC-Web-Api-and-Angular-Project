using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//Add 

using JobMvcApi.Models;
using JobMvcApi.Models.Repository;
using System.Web.Http.Description;

namespace JobMvcApi.Controllers
{
    [RoutePrefix("api/Training")]
    public class TrainingApiController : ApiController
    {
        private IDataAccessRepository<Training, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        public TrainingApiController(IDataAccessRepository<Training, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetTraining", Name = "GetTrainings")]
        public IEnumerable<Training> GetTraining()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetTrainingById/{trainingId}")]
        public IHttpActionResult GetTrainingById(int trainingId)
        {
            return Ok(_repository.Get(trainingId));
        }

        [HttpPost]
        [Route("InsertTraining")]
        public IHttpActionResult PostTraining(Training training)
        {
            _repository.Post(training);
            return Ok(training);
        }
        [HttpPut]
        [Route("UpdateTraining/{trainingId}")]
        public IHttpActionResult PutTraining(int trainingId, Training training)
        {
            _repository.Put(trainingId, training);
            return CreatedAtRoute("GetTrainings", new { Id = training.TrainingID }, training);
        }


        [HttpDelete]
        [Route("DeleteTraining/{trainingId}")]
        public IHttpActionResult DeleteTraining(int trainingId, Training training)
        {
            _repository.Delete(trainingId);
            return CreatedAtRoute("GetTrainings", new { Id = training.TrainingID }, training);
        }
    }
}
