using System;
using System.Collections.Generic;

namespace HYPERION_ASSESSMENT.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Rolename { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
