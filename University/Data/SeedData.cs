using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models.Entities;

namespace University.Data
{
    public class SeedData
    {
        internal static async Task InitAsync(IServiceProvider services)
        {
            using(var db = services.GetRequiredService<UniversityContext>())
            {
                if (await db.Student.AnyAsync()) return;

                var students = GetStudents();

            }
        }

        private static List<Student> GetStudents()
        {
            var students = new List<Student>();


            return students;
        }
    }
}
