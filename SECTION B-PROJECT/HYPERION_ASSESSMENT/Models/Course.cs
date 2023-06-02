using System;
using System.Collections.Generic;

namespace HYPERION_ASSESSMENT.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string Coursename { get; set; }

    public int? Duration { get; set; }
}
