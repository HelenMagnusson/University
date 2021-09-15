using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models.Entities
{

    public class Student : IdentityUser<int>
    {
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        //[NotMapped]
        //public int Blaha { get; set; }

        //Navigation property
        //Nr 2 StudentId skapas som nullable
        public ICollection<Enrollment> Enrollments { get; set; }
        
        //Navigation property
        public Adress Adress { get; set; }

        //Many to many
        public ICollection<Course> Courses { get; set; }
    }
}
