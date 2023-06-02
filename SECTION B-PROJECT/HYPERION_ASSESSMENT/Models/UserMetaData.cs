using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HYPERION_ASSESSMENT.Models
{
    [ModelMetadataType(typeof(UserMetaData))]
    public partial class User
    {

        sealed class UserMetaData
        {
            [Required(ErrorMessage = "Input Email")]
            [DataType(DataType.EmailAddress)]             
            public string Email { get; set; }
            
            [RegularExpression(@"^.*(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*\(\)_\-+=]).*$", ErrorMessage = "Error! Include upper case,numbers,special characters")]
            
            [DataType(DataType.Password)]
            [Required(ErrorMessage ="Input password")]
            public string Password { get; set; }
            [Display(Name = "FIRST NAME")]
            [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Characters are  allowed.")]
            public string Firstname { get; set; }
            [Display(Name = "LAST NAME")]
            [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Characters are  allowed.")]
            public string Lastname { get; set; }
            [Display(Name = "PHONE NUMBER")]
            [DataType(DataType.PhoneNumber)]
          
            public string Phonenumber { get; set; }
            

        }
    }
}
