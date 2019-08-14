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

    using Swashbuckle.AspNetCore.Filters;
    using Swashbuckle.AspNetCore.Swagger;
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

        /// <summary>
        /// Applies the specified operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="context">The context.</param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            this.filter.Apply(operation, context);
        }
    }
}
