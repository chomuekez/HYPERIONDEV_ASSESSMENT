using System;
using System.Collections.Generic;

namespace HYPERION_ASSESSMENT.Models;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public int? UsRid { get; set; }

    public int? UsId { get; set; }

    public virtual User Us { get; set; }

    public virtual Role UsR { get; set; }
}
