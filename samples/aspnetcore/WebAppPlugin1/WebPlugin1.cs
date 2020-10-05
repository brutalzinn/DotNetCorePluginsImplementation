﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Plugin.Abstractions;

namespace Plugin1
{
    internal class WebPlugin1 : IWebPlugin, IPluginLink
    {
        public string GetHref() => "/plugin/v1";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPluginLink, WebPlugin1>();
        }

        public void Configure(IApplicationBuilder appBuilder)
        {
            appBuilder.Map("/plugin/v1", c =>
            {
                var autoMapperType = typeof(AutoMapper.IMapper).Assembly;
                c.Run(async (ctx) =>
                {
                    await ctx.Response.WriteAsync("This plugin uses " + autoMapperType.GetName().ToString());
                });
            });
        }
    }
}
