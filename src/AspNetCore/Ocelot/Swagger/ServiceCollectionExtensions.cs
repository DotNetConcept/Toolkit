namespace DotNetConcept.Toolkit.AspNetCore.Ocelot.Swagger
{
    using Microsoft.Extensions.DependencyInjection;

    public static class MvcServiceCollectionExtensions
	{
		public static IServiceCollection AddOcelotSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen();
			return services;
		}
	}
}