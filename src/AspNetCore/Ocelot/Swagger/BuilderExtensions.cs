namespace DotNetConcept.Toolkit.AspNetCore.Ocelot.Swagger
{
    using System;

    using Microsoft.AspNetCore.Builder;

    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerUI;

    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseOcelotSwagger(this IApplicationBuilder app,
                                                           Action<OcelotSwaggerConfig> configAction,
                                                           Action<SwaggerOptions> swaggerAction = null,
                                                           Action<SwaggerUIOptions> swaggerUIAction = null)
        {
            var config = new OcelotSwaggerConfig();
            configAction?.Invoke(config);

            app.UseSwagger(options => swaggerAction?.Invoke(options));
            app.UseSwaggerUI(options =>
            {
                config.SwaggerEndPoints.ForEach(i => options.SwaggerEndpoint(i.Url, i.Name));
                swaggerUIAction?.Invoke(options);
            });

            app.UseMiddleware<OcelotSwaggerMiddleware>(config);
            return app;
        }
    }
}
