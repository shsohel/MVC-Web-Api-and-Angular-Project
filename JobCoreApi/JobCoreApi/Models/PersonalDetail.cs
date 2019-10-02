using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobCoreApi.Models
{
    public class PersonalDetail
    {
        [Key]
        public int PersonalDetailID { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [Display(Name = "Mother Name")]

        public string MotherName { get; set; }
        [Display(Name = "National ID")]
        public string NationalID { get; set; }

        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        public string Email { get; set; }



        public virtual ICollection<ApplyJob> ApplyJobs { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Education> Educations { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }


    }
}
