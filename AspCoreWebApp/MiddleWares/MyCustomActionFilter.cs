using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreWebApp.MiddleWares
{
    public class MyCustomActionFilter : Attribute, IAsyncActionFilter
    {
        private readonly ILogger<MyCustomActionFilter> logger;

        public MyCustomActionFilter()
        {
            
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Debug.WriteLine("This action filter before the next() call has been executed");
            await next();
            Debug.WriteLine("This action filter after the next() call has been executed");
        }
    }
}
