using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models.Entities
{
    public class Adress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        //FK Not null
        public int StudentId { get; set; }

        //Navigationproperty
        public Student Student { get; set; }
    }
}
