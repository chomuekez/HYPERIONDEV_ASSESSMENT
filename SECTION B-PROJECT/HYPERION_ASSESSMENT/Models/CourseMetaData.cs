using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HYPERION_ASSESSMENT.Models
{
    [ModelMetadataType(typeof(CourseMetaData))]
    public partial class Course
    {
        sealed class CourseMetaData
        {
            [Required(ErrorMessage = "Course name required")]
            [Display(Name = "COURSE NAME")]
           
            [RegularExpression("^[a-zA-Z]+[#]{0,}$", ErrorMessage = "Only Characters are  allowed.")]
            
            public string Coursename { get; set; }

            [Required(ErrorMessage = "Duration required")]
            [Display(Name = "PERIOD OF STUDY(months)")]
            [RegularExpression(@"[1-9]{1,2}", ErrorMessage = "Duration in cannot be less than 0")]
            [RangeAttribute(1,24, ErrorMessage = "Duration   cannot be more than 24 months")]
            public int? Duration { get; set; }

        }
    }
}
