using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HYPERION_ASSESSMENT.Models
{
    [ModelMetadataType(typeof(RoleMetaData))]
    public partial class Role
    {
        sealed class RoleMetaData
        {
            [Required(ErrorMessage = "Role name required")]
            [Display(Name = "ROLE NAME")]
            [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Characters are  allowed.")]
            public string Rolename { get; set; }
        }
    }
}
