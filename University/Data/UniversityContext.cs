using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using University.Models.Entities;
using University.Models.ViewModels.Students;

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

            modelBuilder.Entity<Student>()
                        .HasMany(s => s.Courses)
                        .WithMany(c => c.Students)
                        .UsingEntity<Enrollment>(
                             e => e.HasOne(e => e.Course).WithMany(c => c.Enrollments),
                             e => e.HasOne(e => e.Student).WithMany(s => s.Enrollments));

            //modelBuilder.Entity<Enrollment>().HasKey(x => new { x.StudentId, x.CourseId })

            //Fluent api
            //modelBuilder.Entity<Student>()
            //            .HasMany<Enrollment>(s => s.Enrollments)
            //            .WithOne(e => e.Student)
            //            .HasForeignKey(e => e.StudentId);
        }

    }
}
