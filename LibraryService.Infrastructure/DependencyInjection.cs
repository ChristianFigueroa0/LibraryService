using LibraryService.Domain.Repositories;
using LibraryService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryService.Infrastructure
{
    /// <summary>
    /// Dependency injection to infrastructure layer.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add all required service to use infrastructure layer.
        /// </summary>
        /// <param name="services">DI container.</param>
        /// <returns><see cref="IServiceCollection"/> with infrastructure services added to DI.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlite("Data Source=library.db"));
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
