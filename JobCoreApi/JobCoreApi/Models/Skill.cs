using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobCoreApi.Models
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }
        [Display(Name = "Skill Name")]
        public string SkillName { get; set; }

        public int PersonalDetailID { get; set; }
        public virtual PersonalDetail PersonalDetail { get; set; }
    }
}
