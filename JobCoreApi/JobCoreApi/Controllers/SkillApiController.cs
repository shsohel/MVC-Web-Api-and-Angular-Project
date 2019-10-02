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
    [Route("api/Skill")]
    [ApiController]
    public class SkillApiController : ControllerBase
    {
        private readonly IDataAccessRepository<Skill> _repository;

        public SkillApiController(IDataAccessRepository<Skill> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetSkill")]
        public IActionResult GetSkill()
        {
            IEnumerable<Skill> skills = _repository.GetAll();
            return Ok(skills);
        }

        [HttpGet(Name = "GetSkills")]
        [Route("GetSkillById/{skillsId}")]
        public IActionResult GetSkillById(long skillsId)
        {
            Skill skills = _repository.Get(skillsId);
            if (skills == null)
            {
                return NotFound("Skill record Not Found !!!");
            }
            return Ok(skills);
        }

        [HttpPost]
        [Route("InsertSkill")]
        public IActionResult PostSkill([FromBody] Skill skills)
        {
            if (skills == null)
            {
                return BadRequest("Skill is null!!!!!");
            }
            _repository.Add(skills);
            return CreatedAtRoute("GetSkills", new { Id = skills.SkillID }, skills);
        }

        [HttpPut]
        [Route("UpdateSkill/{skillsId}")]
        public IActionResult PutSkill(long skillsId, [FromBody] Skill skills)
        {
            if (skills == null)
            {
                return BadRequest("Skill is null!!!!");
            }

            Skill skillsToUpdate = _repository.Get(skillsId);
            if (skillsToUpdate == null)
            {
                return NotFound("Skill Record Not Found");
            }
            _repository.Update(skillsToUpdate, skills);
            return CreatedAtRoute("GetSkills", new { Id = skills.SkillID }, skills);
        }

        [HttpPut]
        [Route("DeleteSkill/{skillsId}")]
        public IActionResult DeleteSkill(long skillsId)
        {
            Skill skills = _repository.Get(skillsId);
            if (skills == null)
            {
                return NotFound("ApplyJob Record not Found!!!!");
            }
            _repository.Delete(skills);
            return GetSkill();
        }
    }
}