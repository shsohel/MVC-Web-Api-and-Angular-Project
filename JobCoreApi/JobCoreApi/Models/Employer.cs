using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobCoreApi.Models
{
    public class Employer
    {
        [Key]
        
        public int EmployerID { get; set; }
        //[Required(ErrorMessage = "The User name cannot be blank")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        public string Catageory { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Business Description")]
        public string BusinessDescription { get; set; }

        [Display(Name = "Website Url")]   
        [DataType(DataType.Url)]
        public string WebsiteUrl { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "TelePhone Number")]
        [DataType(DataType.PhoneNumber)]
        public string TelePhone { get; set; }
        
        public string Fax { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        

        public virtual ICollection<JobList> JobLists { get; set; }
        public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; }

    }
}
