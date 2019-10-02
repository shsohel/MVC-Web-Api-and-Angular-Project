﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobCoreApi.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Compnay Business")]
        public string CompnayBusiness { get; set; }

        [Display(Name = "Company Location")]
        public string CompanyLocation { get; set; }

        public string Designation { get; set; }
        public string Department { get; set; }
        public string Responsibilities { get; set; }

        [Display(Name = "StartDate")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Is Continue")]
        public bool IsContinue { get; set; }

        public int PersonalDetailID { get; set; }
        public virtual PersonalDetail PersonalDetail { get; set; }


    }
}