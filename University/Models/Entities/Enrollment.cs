using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models.Entities
{
    public class Enrollment
    {
       // modelbuilder.Entity<Enrollment>().HasKey(x => new {x.StudentId, x.CourseId });
        public int Id { get; set; }
        public int Grade { get; set; }

        //FK
        //nr 4, StudentId Skapas som NotNull! Om jag ändå vill ha som nullable kör med nullable int int?
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        //Navigation property
        //Nr1  StudenId skapas på databasen som nullable
        //Nr 3 nr1 + nr 2 StudenId skapas på databasen som nullable
        // [ForeignKey("Banan")]
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
