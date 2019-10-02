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
    [RoutePrefix("api/Skill")]
    public class SkillApiController : ApiController
    {
        private IDataAccessRepository<Skill, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        public SkillApiController(IDataAccessRepository<Skill, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetSkill", Name = "GetSkills")]
        public IEnumerable<Skill> GetSkill()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetSkillById/{skillId}")]
        public IHttpActionResult GetSkillById(int skillId)
        {
            return Ok(_repository.Get(skillId));
        }

        [HttpPost]
        [Route("InsertSkill")]
        public IHttpActionResult PostSkill(Skill skill)
        {
            _repository.Post(skill);
            return Ok(skill);
        }
        [HttpPut]
        [Route("UpdateSkill/{skillId}")]
        public IHttpActionResult PutSkill(int skillId, Skill skill)
        {
            _repository.Put(skillId, skill);
            return CreatedAtRoute("GetSkills", new { Id = skill.SkillID }, skill);
        }


        [HttpDelete]
        [Route("DeleteSkill/{skillId}")]
        public IHttpActionResult DeleteSkill(int skillId, Skill skill)
        {
            _repository.Delete(skillId);
            return CreatedAtRoute("GetSkills", new { Id = skill.SkillID }, skill);
        }
    }
}
