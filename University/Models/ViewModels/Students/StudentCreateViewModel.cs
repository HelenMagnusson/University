using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using University.Validation;

namespace University.Models.ViewModels.Students
{
    public class StudentCreateViewModel : IValidatableObject
    {
        private const string notAllowed = "Kalle";

        public string FirstName { get; set; }

       // [CheckName]
       // [StringLength(20)]
        public string LastName { get; set; }

        public string Email { get; set; }

        [CheckStreetNr(max: 10)]
        public string AdressStreet { get; set; }
        public string AdressCity { get; set; }
        public string AdressZipCode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(FirstName == notAllowed)
            {
                yield return new ValidationResult($"{notAllowed} is not welcome", new[] { nameof(FirstName)});
            }
        }
    }
}
