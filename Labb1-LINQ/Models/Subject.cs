using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Models
{
    internal class Subject
    {
        [Key]
        public int SubID { get; set; }
        [Required]
        public string SubjectName { get; set; }
        public ICollection<SubjectCourse> SubjectCourses { get; set; }
    }
}
