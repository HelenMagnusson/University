using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using University.Resources;

namespace University.Validation
{
    public class CheckStreetNrAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int max;

        public CheckStreetNrAttribute(int max)
        {
            ErrorMessageResourceType = typeof(ValidationResources);
            ErrorMessageResourceName = "StreetNr";
            this.max = max;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-streetnr", ErrorMessageString);
            context.Attributes.Add("data-val-streetnr-max", $"{max}");
        }

        public override bool IsValid(object value)
        {
            if(value is string input)
            {
                var last = input.Split().Last();
                return int.TryParse(last, out int r) && r <= max;
            }
            return false;
        }
    }
}
