using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Models
{
    internal class SubjectCourse
    {
        public int SubID { get; set; }
        public Subject Subjects { get; set; }
        public int CourseID { get; set; }
        public Course Courses { get; set; }
    }
}
