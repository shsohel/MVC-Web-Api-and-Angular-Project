﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobCoreApi.Models
{
    public class Education
    {
        [Key]
        public int EducationID { get; set; }
        [Display(Name = "Level Of Education")]
        public string LevelOfEducation { get; set; }
        public string CGPA { get; set; }
        public string Scale { get; set; }
        [Display(Name = "Degree Title")]
        public string DegreeTitle { get; set; }
        public string Group { get; set; }
        public string Institute { get; set; }
        [Display(Name = "Passing Year")]

        public string PassingYear { get; set; }
        [DataType(DataType.Duration)]
        public string Duration { get; set; }
        public string Achievement { get; set; }
        public int PersonalDetailID { get; set; }
        public virtual PersonalDetail PersonalDetail { get; set; }

    }
}