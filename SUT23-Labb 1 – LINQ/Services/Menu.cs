using SUT23_Labb_1___LINQ.Data;
using SUT23_Labb_1___LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT23_Labb_1___LINQ.Services
{
    internal class Menu
    {
        // Funktion för att visa huvudmenyn
        public static void ShowMainMenu(SchoolDBContext context)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Hämta alla lärare som lär ut Matte");
                Console.WriteLine("2. Hämsta alla Elever och deras Lärare");
                Console.WriteLine("3. Kolla ifall Programming finns som Ämne");
                Console.WriteLine("4. Byt ut 'Programming' till 'OOP'");
                Console.WriteLine("5. Updatera ifall Elev har lärare 'Anas' till 'Reidar'");
                Console.WriteLine("6. Avsluta");

                Console.Write("\nInput: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        MathTeachers.GetMathTeachers(context);
                        break;
                    case 2:
                        StudentServices.GetStudentsWithTeachers(context);
                        break;
                    case 3:
                        CourseServices.CheckSubjectExistence(context);
                        break;
                    case 4:
                        CourseServices.EditSubject(context);
                        break;
                    case 5:
                        StudentServices.UpdateStudentRecord(context);
                        break;
                    case 6:
                        Console.WriteLine("Programmet Avslutas...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please select a valid option.");
                        break;
                }
            }
        }
    }
}
