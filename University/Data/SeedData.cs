﻿using Bogus;
using Microsoft.AspNetCore.Identity;
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
        private static Faker fake;

        internal static async Task InitAsync(IServiceProvider services)
        {
            using(var db = services.GetRequiredService<UniversityContext>())
            {
                if (await db.Student.AnyAsync()) return;

                const string passWord = "bytmig";
                const string roleName = "Student";

                var userManager = services.GetRequiredService<UserManager<Student>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

                var role = new IdentityRole<int> { Name = roleName };
                var addRoleResult = await roleManager.CreateAsync(role);

                fake = new Faker("sv");

                var students = GetStudents();
                //await db.AddRangeAsync(students);

                foreach (var student in students)
                {
                   var result =   await userManager.CreateAsync(student, passWord);
                    if (!result.Succeeded) throw new Exception(String.Join("\n", result.Errors));
                    await userManager.AddToRoleAsync(student, roleName);
                }

                var courses = GetCourses();
                await db.AddRangeAsync(courses);

                var enrollments = GetEnrollments(students, courses);
                await db.AddRangeAsync(enrollments);

                await db.SaveChangesAsync();
            }
        }

        private static List<Enrollment> GetEnrollments(List<Student> students, List<Course> courses)
        {
            var enrollments = new List<Enrollment>();

            foreach (var student in students)
            {
                foreach (var course in courses)
                {
                    if(fake.Random.Int(0,5) == 0)
                    {
                        var enrollment = new Enrollment
                        {
                            Course = course,
                            Student = student,
                            Grade = fake.Random.Int(1, 5)
                        };
                        enrollments.Add(enrollment);
                    }
                }
            }

            return enrollments;
        }

        private static List<Course> GetCourses()
        {
            var courses = new List<Course>();

            for (int i = 0; i < 20; i++)
            {
                var course = new Course
                {
                    Title = fake.Company.CatchPhrase()
                };

                courses.Add(course);
            }

            return courses;
        }

        private static List<Student> GetStudents()
        {
            var students = new List<Student>();

            for (int i = 0; i < 200; i++)
            {
                var fName = fake.Name.FirstName();
                var lName = fake.Name.LastName();
                var email = fake.Internet.Email($"{fName} {lName}");
                var student = new Student
                {
                    FirstName = fName,
                    LastName = lName,
                    Email = email,
                    UserName = email,
                    Avatar = fake.Internet.Avatar(),
                    Adress = new Adress
                    {
                        City = fake.Address.City(),
                        Street = fake.Address.StreetAddress(),
                        ZipCode = fake.Address.ZipCode()
                    }
                };
                students.Add(student);
            }

            return students;
        }
    }
}
