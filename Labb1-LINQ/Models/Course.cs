using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Models
{
    internal class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Required]
        public string CourseName { get; set; }
        public ICollection<SubjectCourse> Subjects { get; set; }
        public ICollection<StudentCourse> Students { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
    }
}
