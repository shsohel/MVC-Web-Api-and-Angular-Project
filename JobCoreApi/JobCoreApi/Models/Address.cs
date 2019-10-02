using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobCoreApi.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        //[Required]
        //[StringLength(50,MinimumLength =3 ,ErrorMessage ="Please Enter Present Address details between 3 and 50 characters in length")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Please enter Present Address beginning with a capital letter and made up of letters and spaces only")]
        //[Display(Name = "Present Address")]
        public string PresentAddress { get; set; }

        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Please Enter Permanent Address details between 3 and 50 characters in length")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Please enter Permanent Address beginning with a capital letter and made up of letters and spaces only")]
        //[Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }

        public int PersonalDetailID { get; set; }
        public virtual PersonalDetail PersonalDetail { get; set; }

    }
}
