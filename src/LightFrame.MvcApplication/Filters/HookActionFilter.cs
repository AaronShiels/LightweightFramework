using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LightFrame.MvcApplication.Filters
{
    public class HookActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new Exception();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new Exception();
        }
    }
}
