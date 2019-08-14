namespace DotNetConcept.Toolkit.AspNetCore.Swagger
{
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    using JetBrains.Annotations;

    using Microsoft.Extensions.DependencyInjection;

    using Swashbuckle.AspNetCore.SwaggerGen;

    public static class SwaggerExtensions
    {
        public static void IncludeXmlComments([NotNull]this SwaggerGenOptions options, [NotNull]Assembly assembly)
        {

            var assemblyLocation = assembly.Location;
            var xmlPath = Path.ChangeExtension(assemblyLocation, "xml");
            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath);
                Debug.WriteLine("Documentation file found for Swagger : {0}", new object[] { xmlPath });
            }
            else
            {
                Debug.WriteLine("Documentation file not found for Swagger : {0}", new object[] { xmlPath });
            }
        }
    }
}
