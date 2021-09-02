using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Validation;

namespace University.Models.ViewModels.Students
{
    public class StudentCreateViewModel
    {
        public string FirstName { get; set; }

        [CheckName]
        public string LastName { get; set; }

        public string Email { get; set; }

        [CheckStreetNr(max: 10)]
        public string AdressStreet { get; set; }
        public string AdressCity { get; set; }
        public string AdressZipCode { get; set; }
    }
}
