using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class StudentsDbSeeder
    {
        public static void Initialize(StudentsDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students
            if (context.Students.Any())
            {
                return;
            }

            context.Students.AddRange(
                new Student
                {
                    FirstName = "Alina",
                    LastName = "Demian",
                    Average = 10.0f,
                    Birthday = new DateTime(1993, 12, 13),
                    Gender = 'F'
                },
                new Student
                {
                    FirstName = "prenume",
                    LastName = "nume",
                    Average = 9.50f,
                    Birthday = new DateTime(2018, 12, 13),
                    Gender = 'M'
                }
            );
            context.SaveChanges();
        }
    }
}
