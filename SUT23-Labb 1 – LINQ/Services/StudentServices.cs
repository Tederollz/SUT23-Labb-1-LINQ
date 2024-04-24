using SUT23_Labb_1___LINQ.Data;
using SUT23_Labb_1___LINQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT23_Labb_1___LINQ.Services
{
    internal class StudentServices
    {
        // Funktion för att hämta elever med sina lärare
        public static void GetStudentsWithTeachers(SchoolDBContext context)
        {
            var studentsWithTeachers = context.Students
                .Include(s => s.Course)
                .ThenInclude(c => c.Teachers)
                .ThenInclude(t => t.Subjects)
                .ToList();

            Console.WriteLine("\nElever och deras Lärare:");
            foreach (var student in studentsWithTeachers)
            {
                Console.Write($"{student.Name} - Lärare: ");
                foreach (var teacher in student.Course.Teachers)
                {
                    foreach (var subject in teacher.Subjects)
                    {
                        Console.Write($"{teacher.Name} ({subject.Name}), ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        // Funktion för att uppdatera en students inspelning
        public static void UpdateStudentRecord(SchoolDBContext context)
        {
            var newTeacher = context.Teachers.FirstOrDefault(t => t.Name == "Reidar");
            var anasTeacher = context.Teachers.FirstOrDefault(t => t.Name == "Anas");

            if (newTeacher != null && anasTeacher != null)
            {
                var studentsToUpdate = context.Students
                    .Where(s => s.Course.Teachers.Any(t => t.Name == "Anas"))
                    .ToList();

                foreach (var student in studentsToUpdate)
                {
                    var course = student.Course;
                    if (course.Teachers.Contains(anasTeacher))
                    {
                        course.Teachers.Remove(anasTeacher);
                        course.Teachers.Add(newTeacher);
                    }
                }

                context.SaveChanges();
                Console.WriteLine("Updaterat!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Anas or Reidar not found!");
                Console.ReadKey();
            }
        }
    }
}
