using System;
using System.Collections.Generic;

namespace Functions101.Models.Toons
{
    public partial class Instructor
    {
        public Instructor()
        {
            Courses = new HashSet<Course>();
        }

        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
