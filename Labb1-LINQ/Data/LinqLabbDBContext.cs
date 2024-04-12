using Labb1_LINQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Data
{
    internal class LinqLabbDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<SubjectCourse> SubjectCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = RASMUS-LAPTOP;Initial Catalog = LINQLabb1;Integrated Security=True;TrustServerCertificate = Yes");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relations
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SubjectCourse>()
                .HasKey(ma => new { ma.SubID, ma.CourseID });

            modelBuilder.Entity<SubjectCourse>()
                .HasOne(ma => ma.Courses)
                .WithMany(m => m.Subjects)
                .HasForeignKey(ma => ma.CourseID);

            modelBuilder.Entity<SubjectCourse>()
                .HasOne(ma => ma.Subjects)
                .WithMany(a => a.SubjectCourses)
                .HasForeignKey(ma => ma.SubID);



            modelBuilder.Entity<StudentCourse>()
                .HasKey(ma => new { ma.StudentID, ma.CourseID });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(ma => ma.Courses)
                .WithMany(m => m.Students)
                .HasForeignKey(ma => ma.CourseID);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(ma => ma.Students)
                .WithMany(a => a.StudentCourses)
                .HasForeignKey(ma => ma.StudentID);



            // Test Data
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentID = 1,
                StudentName = "Fredrik",
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentID = 2,
                StudentName = "Johan",
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentID = 3,
                StudentName = "Sara",
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentID = 4,
                StudentName = "Peter",
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentID = 5,
                StudentName = "Susan",
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentID = 6,
                StudentName = "Annie",
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentID = 7,
                StudentName = "Henrik",
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentID = 8,
                StudentName = "Stina",
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentID = 9,
                StudentName = "Petronella",
            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentID = 10,
                StudentName = "Leon",
            });



            modelBuilder.Entity<Teacher>().HasData(new Teacher
            {
                TeacherID = 1,
                TeacherName = "Anas",
            });
            modelBuilder.Entity<Teacher>().HasData(new Teacher
            {
                TeacherID = 2,
                TeacherName = "Reidar",
            });
            modelBuilder.Entity<Teacher>().HasData(new Teacher
            {
                TeacherID = 3,
                TeacherName = "Tobias",
            });



            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseID = 1,
                CourseName = "Programmering",
                TeacherID = 1,
            });
            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseID = 2,
                CourseName = "Språk",
                TeacherID = 2,
            });
            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseID = 3,
                CourseName = "Matematik",
                TeacherID = 3,
            });



            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                SubID = 1,
                SubjectName = "Programmering 1"
            });
            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                SubID = 2,
                SubjectName = "Programmering 2"
            });
            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                SubID = 3,
                SubjectName = "Avancerad .NET"
            });
            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                SubID = 4,
                SubjectName = "Svenska"
            });
            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                SubID = 5,
                SubjectName = "Engelska"
            });
            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                SubID = 6,
                SubjectName = "Geometri"
            });
            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                SubID = 7,
                SubjectName = "Algebra"
            });



            modelBuilder.Entity<SubjectCourse>().HasData(new SubjectCourse
            {
                SubID = 1,
                CourseID = 1,
            });
            modelBuilder.Entity<SubjectCourse>().HasData(new SubjectCourse
            {
                SubID = 2,
                CourseID = 1,
            });
            modelBuilder.Entity<SubjectCourse>().HasData(new SubjectCourse
            {
                SubID = 3,
                CourseID = 1,
            });
            modelBuilder.Entity<SubjectCourse>().HasData(new SubjectCourse
            {
                SubID = 4,
                CourseID = 2,
            });
            modelBuilder.Entity<SubjectCourse>().HasData(new SubjectCourse
            {
                SubID = 5,
                CourseID = 2,
            });
            modelBuilder.Entity<SubjectCourse>().HasData(new SubjectCourse
            {
                SubID = 6,
                CourseID = 3,
            });
            modelBuilder.Entity<SubjectCourse>().HasData(new SubjectCourse
            {
                SubID = 7,
                CourseID = 3,
            });



            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
            {
                StudentID = 1,
                CourseID = 1,
            });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
            {
                StudentID = 2,
                CourseID = 1,
            });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
            {
                StudentID = 3,
                CourseID = 1,
            });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
            {
                StudentID = 4,
                CourseID = 2,
            });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
            {
                StudentID = 5,
                CourseID = 2,
            });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
            {
                StudentID = 6,
                CourseID = 3,
            });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
            {
                StudentID = 7,
                CourseID = 3,
            });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
            {
                StudentID = 8,
                CourseID = 3,
            });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
            {
                StudentID = 9,
                CourseID = 1,
            });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
            {
                StudentID = 10,
                CourseID = 1,
            });

        }
    }
}
