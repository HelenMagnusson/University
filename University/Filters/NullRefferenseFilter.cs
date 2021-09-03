using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Filters
{
    public class NullRefferenseFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is NullReferenceException)
            {
                context.Result = new StatusCodeResult(500);
            }
        }
    }
}
