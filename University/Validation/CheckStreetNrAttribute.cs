using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace University.Validation
{
    public class CheckStreetNrAttribute : ValidationAttribute
    {
        private readonly int max;

        public CheckStreetNrAttribute(int max)
        {
            this.max = max;
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
