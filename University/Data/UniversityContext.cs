using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using University.Models.Entities;
using University.Models.ViewModels.Students;

namespace University.Data
{
    public class UniversityContext : IdentityDbContext<Student , IdentityRole<int>, int>
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<University.Models.Entities.Course> Course { get; set; }
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

            modelBuilder.Entity<Student>().Property<DateTime>("Edited");

            //foreach (var entity in modelBuilder.Model.GetEntityTypes())
            //{
            //    entity.AddProperty("Edited", typeof(DateTime));
            //}

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


        //public override int SaveChanges()
        //{
        //    ChangeTracker.DetectChanges();

        //    foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
        //    {
        //        entry.Property("Edited").CurrentValue = DateTime.Now;
        //    }

        //    return base.SaveChanges();
        //}

      
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            {
                entry.Property("Edited").CurrentValue = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
