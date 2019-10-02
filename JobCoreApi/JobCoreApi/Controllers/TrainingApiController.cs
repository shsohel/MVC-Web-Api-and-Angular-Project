using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using JobCoreApi.Models;
using JobCoreApi.Models.Repository;

namespace JobCoreApi.Controllers
{
    [Route("api/Training")]
    [ApiController]
    public class TrainingApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Training> _repository;

        public TrainingApiController(IDataAccessRepository<Training> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetTraining")]
        public IActionResult GetTraining()
        {
            IEnumerable<Training> trainings = _repository.GetAll();
            return Ok(trainings);
        }

        [HttpGet(Name = "GetTrainings")]
        [Route("GetTrainingById/{trainingsId}")]
        public IActionResult GetTrainingById(long trainingsId)
        {
            Training trainings = _repository.Get(trainingsId);
            if (trainings == null)
            {
                return NotFound("Training record Not Found !!!");
            }
            return Ok(trainings);
        }

        [HttpPost]
        [Route("InsertTraining")]
        public IActionResult PostTraining([FromBody] Training trainings)
        {
            if (trainings == null)
            {
                return BadRequest("Training is null!!!!!");
            }
            _repository.Add(trainings);
            return CreatedAtRoute("GetTrainings", new { Id = trainings.TrainingID }, trainings);
        }

        [HttpPut]
        [Route("UpdateTraining/{trainingsId}")]
        public IActionResult PutTraining(long trainingsId, [FromBody] Training trainings)
        {
            if (trainings == null)
            {
                return BadRequest("Training is null!!!!");
            }

            Training trainingsToUpdate = _repository.Get(trainingsId);
            if (trainingsToUpdate == null)
            {
                return NotFound("Training Record Not Found");
            }
            _repository.Update(trainingsToUpdate, trainings);
            return CreatedAtRoute("GetTrainings", new { Id = trainings.TrainingID }, trainings);
        }

        [HttpPut]
        [Route("DeleteTraining/{trainingsId}")]
        public IActionResult DeleteTraining(long trainingsId)
        {
            Training trainings = _repository.Get(trainingsId);
            if (trainings == null)
            {
                return NotFound("Training Record not Found!!!!");
            }
            _repository.Delete(trainings);
            return GetTraining();
        }
    }
}