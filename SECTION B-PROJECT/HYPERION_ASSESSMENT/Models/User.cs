using System;
using System.Collections.Generic;

namespace HYPERION_ASSESSMENT.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Phonenumber { get; set; }
   
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    

}
