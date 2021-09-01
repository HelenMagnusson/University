using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using University.Models.Entities;

namespace University.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public UniversityContext (DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           //modelBuilder.Entity<Enrollment>().HasKey(x => new { x.StudentId, x.CourseId })

            //Fluent api
            //modelBuilder.Entity<Student>()
            //            .HasMany<Enrollment>(s => s.Enrollments)
            //            .WithOne(e => e.Student)
            //            .HasForeignKey(e => e.StudentId);
        }

    }
}
