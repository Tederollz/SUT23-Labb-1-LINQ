using SUT23_Labb_1___LINQ.Data;
using SUT23_Labb_1___LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT23_Labb_1___LINQ.Services
{
    internal class TestData
    {
        // Funktion för att fylla på databasen med grundläggande data
        public static void SeedDatabase(SchoolDBContext context)
        {
            // Kolla om databasen redan har data
            if (!context.Teachers.Any())
            {
                // Skapa och lägg till ämnen
                var subject1 = new Subject { Name = "Matte" };
                var subject2 = new Subject { Name = "Programming" };
                var subject3 = new Subject { Name = "Avancerad.Net" };
                var subject4 = new Subject { Name = "Engelska" };
                context.Subjects.AddRange(subject1, subject2, subject3, subject4);

                // Skapa och lägg till lärare
                var teacher1 = new Teacher { Name = "Johanna", Subjects = new List<Subject> { subject1, subject4 } };
                var teacher2 = new Teacher { Name = "Anas", Subjects = new List<Subject> { subject2, subject3 } };
                var teacher3 = new Teacher { Name = "Pär", Subjects = new List<Subject> { subject2 } };
                var teacher4 = new Teacher { Name = "Jonas", Subjects = new List<Subject> { subject1, subject4 } };
                var teacher5 = new Teacher { Name = "Reidar", Subjects = new List<Subject> { subject2, subject3 } };
                context.Teachers.AddRange(teacher1, teacher2, teacher3, teacher4, teacher5);

                // Skapa och lägg till kurser
                var course1 = new Course { Name = "SUT23", 
                    Subjects = new List<Subject> { subject3, subject2 }, 
                    Teachers = new List<Teacher> { teacher2, teacher3 } };
                var course2 = new Course { Name = "ITP22", 
                    Subjects = new List<Subject> { subject1, subject4 }, 
                    Teachers = new List<Teacher> { teacher1, teacher3, teacher4 } };
                context.Courses.AddRange(course1, course2);

                // Skapa och lägg till studenter
                var student1 = new Student { Name = "Alice", Course = course2 };
                var student2 = new Student { Name = "Bob", Course = course2 };
                var student3 = new Student { Name = "Linus", Course = course1 };
                var student4 = new Student { Name = "Anna", Course = course1 };
                var student5 = new Student { Name = "Robert", Course = course2 };
                var student6 = new Student { Name = "Max", Course = course1 };
                context.Students.AddRange(student1, student2, student3, student4, student5, student6);


                context.SaveChanges();
                Console.WriteLine("Test data har lagt till.");
                Console.ReadKey();
            }
        }
    }
}
