using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Models
{
    internal class StudentCourse
    {
        public int StudentID { get; set; }
        public Student Students { get; set; }
        public int CourseID { get; set; }
        public Course Courses { get; set; }
    }
}
