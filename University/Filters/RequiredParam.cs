using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Filters
{
    public class RequiredParam : ActionFilterAttribute
    {
        private readonly string name;

        public RequiredParam(string name)
        {
            this.name = name;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
           if(!context.ActionArguments.TryGetValue(name, out object _))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
