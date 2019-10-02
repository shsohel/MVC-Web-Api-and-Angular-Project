﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobCoreApi.Models
{
    public class ApplyJob
    {
        [Key]
        public int ApplyJobID { get; set; }
        public int JobListID { get; set; }
        public virtual JobList JobList { get; set; }
        public int PersonalDetailID { get; set; }
        public virtual PersonalDetail PersonalDetail { get; set; }

    }
}
