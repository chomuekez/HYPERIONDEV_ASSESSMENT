using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HYPERION_ASSESSMENT.Models
{
    [ModelMetadataType(typeof(StudentMetaData))]
    public partial class Student
    {
        sealed class StudentMetaData
        {
            [Required(ErrorMessage="Full name required")]
            [Display(Name = "STUDENT NAME")]
            [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Characters are  allowed.")]
            public string Studentname { get; set; }
            [Display(Name = "FIRST NAME")]
            [Required(ErrorMessage = "First name required")]
            [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Characters are  allowed.")]
            public string Firstname { get; set; }
            [Required(ErrorMessage = "Last name required")]
            [Display(Name = "LAST NAME")]
            [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Characters are  allowed.")]
            public string Lastname { get; set; }
            [Required(ErrorMessage = "Country name required")]
            [Display(Name = "COUNTRY")]
            [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Characters are  allowed.")]
            public string Country { get; set; }

        }
    }
}
