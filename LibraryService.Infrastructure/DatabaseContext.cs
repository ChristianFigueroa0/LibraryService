using LibraryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryService.Infrastructure
{
    /// <summary>
    /// Database context.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// The books dataset allows access to <see cref="Book"/>.
        /// </summary>
        public DbSet<Book> Books { get; set; }
        /// <inheritdoc/>
        public DatabaseContext(DbContextOptions options) : base(options) {
        }
        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
