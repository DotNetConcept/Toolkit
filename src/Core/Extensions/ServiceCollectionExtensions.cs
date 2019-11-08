namespace DotNetConcept.Toolkit.Extensions
{
    using JetBrains.Annotations;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    public static class ServiceCollectionExtensions
    {
        public static void AddScopedOptions<TOptions>([NotNull] this IServiceCollection services)
            where TOptions : class, new()
        {
            services.AddScoped(sp => sp.GetService<IOptionsSnapshot<TOptions>>().Value);
        }
    }
}
