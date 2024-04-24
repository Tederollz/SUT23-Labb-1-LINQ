using SUT23_Labb_1___LINQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT23_Labb_1___LINQ.Services
{
    internal class MathTeachers
    {
        // Funktion för att hämta lärare som undervisar matte
        public static void GetMathTeachers(SchoolDBContext context)
        {
            var mathTeachers = context.Teachers.Where(t => t.Subjects.Any(s => s.Name == "Matte")).ToList();
            Console.WriteLine("\nLärare som lär ut Matte:");
            foreach (var teacher in mathTeachers)
            {
                Console.WriteLine(teacher.Name);
            }
            Console.ReadKey();
        }
    }
}
