using LightFrame.Core.Middleware;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightFrame.MvcApplication.Middleware
{
    public class ActionMiddleware
    {
        private readonly RequestDelegate _httpNext;
        private readonly IEnumerable<IActionMiddleware> _messageMiddlewares;

        public ActionMiddleware(RequestDelegate httpNext, IEnumerable<IActionMiddleware> messageMiddlewares)
        {
            _httpNext = httpNext;
            _messageMiddlewares = messageMiddlewares;
        }

        private static Func<ActionDelegate, ActionDelegate> Map(IActionMiddleware mm)
        {
            return next => async message => await mm.Invoke(message, next);
        }

        public async Task Invoke(HttpContext context)
        {
            var metadata = new ActionMetadata(context.Request.Path, ActionMetadata.MessageType.Web);

            ActionDelegate pipeline = async message => await _httpNext.Invoke(context);

            var orderedComponents = _messageMiddlewares
                .OrderBy(mm => mm.Priority)
                .Select(Map);

            foreach (var component in orderedComponents.Reverse())
                pipeline = component(pipeline);

            await pipeline(metadata);
        }
    }
}
