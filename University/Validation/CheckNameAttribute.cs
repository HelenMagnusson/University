using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using University.Models.ViewModels.Students;

namespace University.Validation
{
    public class CheckNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            const string errorMessage = "Fail from check name";

            if(value is string input)
            {
                var model = (StudentCreateViewModel)validationContext.ObjectInstance;
                if (model.FirstName == "Kalle" && input == "Anka")
                    return ValidationResult.Success;
                else
                    return new ValidationResult(errorMessage);
            }
            return new ValidationResult(errorMessage);
        }
    }
}
