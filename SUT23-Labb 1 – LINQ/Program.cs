using SUT23_Labb_1___LINQ.Data;
using SUT23_Labb_1___LINQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace SUT23_Labb_1___LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                // Skapar och lägger till ämnen
                var mathSubject = new Subject { Name = "Mathematics" };
                var programmingSubject = new Subject { Name = "Programming" };
                context.Subjects.AddRange(mathSubject, programmingSubject);
                context.SaveChanges();

                // Skapar och lägger till lärare
                var mathTeacher = new Teacher { Name = "Johanna", Subjects = new List<Subject> { mathSubject } };
                var programmingTeacher = new Teacher { Name = "Anas", Subjects = new List<Subject> { programmingSubject } };
                context.Teachers.AddRange(mathTeacher, programmingTeacher);
                context.SaveChanges();

                // Skapar och lägger till kurser
                var mathCourse = new Course { Name = "Mathematics", Subjects = new List<Subject> { mathSubject } };
                var programmingCourse = new Course { Name = "Programming", Subjects = new List<Subject> { programmingSubject } };
                context.Courses.AddRange(mathCourse, programmingCourse);
                context.SaveChanges();

                // Skapar och lägger till studenter
                var student1 = new Student { Name = "Alice", Teacher = mathTeacher };
                var student2 = new Student { Name = "Bob", Teacher = programmingTeacher };
                context.Students.AddRange(student1, student2);
                context.SaveChanges();

                // Hämta alla lärare som undervisar matte
                var mathTeachers = context.Teachers.Where(t => t.Subjects.Any(s => s.Name == "Mathematics")).ToList();
                Console.WriteLine("Teachers who teach Mathematics:");
                foreach (var teacher in mathTeachers)
                {
                    Console.WriteLine(teacher.Name);
                }

                // Hämta alla elever med sina lärare.
                var studentsWithTeachers = context.Students.Include(s => s.Teacher).ToList();
                Console.WriteLine("\nStudents with their teachers:");
                foreach (var student in studentsWithTeachers)
                {
                    Console.WriteLine($"{student.Name} - {student.Teacher.Name}");
                }

                // Kolla om ämnen tabell Contains programmering1 eller inte.
                var containsProgramming = context.Subjects.Any(s => s.Name == "Programming");
                Console.WriteLine($"\nDoes Subjects table contain 'Programming'? {(containsProgramming ? "Yes" : "No")}");

                // Editera en Ämne från programmering2 till OOP
                var programmingSubjectToUpdate = context.Subjects.FirstOrDefault(s => s.Name == "Programming");
                if (programmingSubjectToUpdate != null)
                {
                    programmingSubjectToUpdate.Name = "OOP";
                    context.SaveChanges();
                }

                // Uppdatera en student record om sin lärare är Anas till Reidar.
                var studentToUpdate = context.Students.FirstOrDefault(s => s.Teacher.Name == "Anas");
                var newTeacher = context.Teachers.FirstOrDefault(t => t.Name == "Reidar");
                if (studentToUpdate != null && newTeacher != null)
                {
                    studentToUpdate.Teacher = newTeacher;
                    context.SaveChanges();
                }
            }
        }
    }
}
