using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SUT23_Labb_1___LINQ.Data;
using SUT23_Labb_1___LINQ.Models;
using SUT23_Labb_1___LINQ.Services;

namespace SUT23_Labb_1___LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolDBContext())
            {
                // Fyll på databasen med grundläggande data vid programmets start
                TestData.SeedDatabase(context);
                // Visa huvudmenyn
                Menu.ShowMainMenu(context);
            }
        }
    }
}
