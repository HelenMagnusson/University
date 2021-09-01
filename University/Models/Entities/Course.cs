using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //Nav prop
        public ICollection<Enrollment> Enrollments { get; set; }

        //N:M
        public ICollection<Student> Students { get; set; }
    }
}
