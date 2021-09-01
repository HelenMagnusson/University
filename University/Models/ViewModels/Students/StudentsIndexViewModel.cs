using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models.ViewModels.Students
{
    public class StudentsIndexViewModel
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Fullname { get; set; }
        public string Street { get; set; }
    }
}
