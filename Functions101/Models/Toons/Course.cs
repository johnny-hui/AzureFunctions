using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Course
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public int InstructorId { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}
