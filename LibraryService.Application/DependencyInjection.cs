using LibraryService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryService.Application
{
    /// <summary>
    /// Dependency injection to application layer.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add all required service to use application layer.
        /// </summary>
        /// <param name="services">DI container.</param>
        /// <returns><see cref="IServiceCollection"/> with application services added to DI.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IBooksService, BooksService>();
            return services;
        }
    }
}
