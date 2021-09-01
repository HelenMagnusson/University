using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models.Entities
{
   // [Table(name: "TableName")]
    public class Student
    {
        //[Key]
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        //[NotMapped]
        //public int Blaha { get; set; }

        //Navigation property
        //Nr 2 StudentId skapas som nullable
        public ICollection<Enrollment> Enrollments { get; set; }
        
        //Navigation property
        public Adress Adress { get; set; }
    }
}
