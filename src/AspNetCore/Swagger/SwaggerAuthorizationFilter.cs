// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwaggerAuthorizationFilter.cs" company="Cityway">
//   Copyright © Cityway 2018
// </copyright>
// <summary>
//   Defines the SwaggerAuthorizationFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotNetConcept.Toolkit.AspNetCore.Swagger
{
    using System.Linq;

    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.Filters;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class SwaggerAuthorizationFilter : IOperationFilter
    {
        /// <summary>
        /// The filter.
        /// </summary>
        private SecurityRequirementsOperationFilter<SwaggerAuthorizeAttribute> filter;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerAuthorizationFilter"/> class.
        /// </summary>
        /// <param name="includeUnauthorizedAndForbiddenResponses">
        /// The include unauthorized and forbidden responses.
        /// </param>
        /// <param name="securitySchemaName">
        /// The security schema name.
        /// </param>
        public SwaggerAuthorizationFilter(
            bool includeUnauthorizedAndForbiddenResponses = true,
            string securitySchemaName = "oauth2")
        {
            this.filter = new SecurityRequirementsOperationFilter<SwaggerAuthorizeAttribute>(authAttributes => Enumerable.Empty<string>(), includeUnauthorizedAndForbiddenResponses, securitySchemaName);
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            this.filter.Apply(operation, context);
        }
    }
}
