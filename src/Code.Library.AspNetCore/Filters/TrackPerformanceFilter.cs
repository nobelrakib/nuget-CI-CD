﻿using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Code.Library.AspNetCore.Filters
{
    public class TrackPerformanceFilter : IActionFilter
    {
        private PerfTracker _tracker;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
                _tracker?.Stop();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(context.ActionDescriptor is ControllerActionDescriptor cad)) return;

            _tracker = new PerfTracker($"{cad.ControllerName}-{cad.ActionName}");
        }
    }
}