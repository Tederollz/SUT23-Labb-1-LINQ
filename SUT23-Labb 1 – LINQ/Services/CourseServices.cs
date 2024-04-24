using SUT23_Labb_1___LINQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT23_Labb_1___LINQ.Services
{
    internal class CourseServices
    {
        // Funktion för att kontrollera om ett ämne finns
        public static void CheckSubjectExistence(SchoolDBContext context)
        {
            var containsProgramming = context.Subjects.Any(s => s.Name == "Programming");
            Console.WriteLine($"\nFinns ämnet 'Programming'? {(containsProgramming ? "Ja" : "Nej")}");
            Console.ReadKey();
        }

        // Funktion för att ändra ett ämnes namn från 'Programming' till 'OOP'
        public static void EditSubject(SchoolDBContext context)
        {
            var subjectToEdit = context.Subjects.FirstOrDefault(s => s.Name == "Programming");
            if (subjectToEdit != null)
            {
                subjectToEdit.Name = "OOP";
                context.SaveChanges();
                Console.WriteLine("Ämnet 'Programming' har byts till 'OOP'.");
                Console.ReadKey();
            }
            else
            {
                // Om 'Programming' inte hittas, ändra tillbaka till 'Programming'
                var subjectOOP = context.Subjects.FirstOrDefault(s => s.Name == "OOP");
                if (subjectOOP != null)
                {
                    subjectOOP.Name = "Programming";
                    context.SaveChanges();
                    Console.WriteLine("Ämnet 'OOP' har byts tillbaka till 'Programming'.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Subject 'Programming' not found!");
                }
            }
        }
    }
}
