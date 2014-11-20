﻿using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Glimpse.Web;
using System;

namespace Glimpse.Host.Web.AspNet
{
    public class GlimpseMiddleware
    {
        private readonly RequestDelegate _innerNext;
        private readonly MasterRequestRuntime _runtime;

        public GlimpseMiddleware(RequestDelegate innerNext, IServiceProvider serviceProvider)
        {
            _innerNext = innerNext;
            _runtime = new MasterRequestRuntime(serviceProvider);
        }

        public async Task Invoke(Microsoft.AspNet.Http.HttpContext context)
        {
            var newContext = new HttpContext(context);

            _runtime.Begin(newContext);

            await _innerNext(context);

            _runtime.End(newContext);
        }
    }
}