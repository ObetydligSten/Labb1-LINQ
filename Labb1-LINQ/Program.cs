using Labb1_LINQ.Data;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Labb1_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using LinqLabbDBContext db = new LinqLabbDBContext();


            // Hämta alla lärare som undervisar matte

            var mathTeacher = (from c in db.Courses
                               join t in db.Teachers
                               on c.TeacherID equals t.TeacherID
                               where c.CourseName == "Matematik"
                               select new
                               {
                                   tName = t.TeacherName
                               }).ToList();
            foreach ( var t in mathTeacher )
            {
                Console.WriteLine($"Matematik lärare : {t.tName}");
            }

            Console.WriteLine("-------------------------------------");


            // Hämta alla elever med sina lärare

            var studentTeacher = (from c in db.Courses
                               join t in db.Teachers
                               on c.TeacherID equals t.TeacherID
                               from sc in db.StudentCourses
                               join s in db.Students on sc.StudentID equals s.StudentID
                               where sc.CourseID == c.CourseID
                               select new
                               {
                                   tName = t.TeacherName,
                                   sName = s.StudentName
                               }).ToList();
            foreach (var t in studentTeacher)
            {
                Console.WriteLine($"Student : {t.sName} , Lärare : {t.tName}");
            }

            Console.WriteLine("-----------------------------------");


            // Kolla om ämnen tabellen innehåller programmering 1 eller inte

            var subjectProg1 = db.Subjects.Any(s => s.SubjectName == "Programmering 1");
            if (subjectProg1)
            {
                Console.WriteLine("Programmering 1 finns som ämne");
            }
            else
            {
                Console.WriteLine("Programmering 1 finns INTE som ämne");
            }

            Console.WriteLine("--------------------------------");


            // Editera ett ämne från programmering 2 till OOP

            var subEdit = db.Subjects.FirstOrDefault(s => s.SubjectName == "Programmering 2");

            if (subEdit != null)
            {
                subEdit.SubjectName = "OOP";

                db.SaveChanges();
            }

            var subName = db.Subjects.FirstOrDefault(s => s.SubjectName == "Programmering 2" || s.SubjectName == "OOP");
            Console.WriteLine(subName.SubjectName);

            Console.WriteLine("------------------------------------");


            // Uppdatera en student record om sin lärare är Anas till Reidar


            var updateTeacher = (from c in db.Courses
                                  join t in db.Teachers
                                  on c.TeacherID equals t.TeacherID
                                  from sc in db.StudentCourses
                                  join s in db.Students on sc.StudentID equals s.StudentID
                                  where sc.CourseID == c.CourseID
                                  select new
                                  {
                                      tName = t.TeacherName == "Anas" ? "Reidar" : t.TeacherName,
                                      sName = s.StudentName
                                  }).ToList();

            foreach (var t in updateTeacher)
            {
                Console.WriteLine($" Student name : {t.sName} , Teacher name : {t.tName}");
            }


            Console.ReadKey();



        }
    }
}
