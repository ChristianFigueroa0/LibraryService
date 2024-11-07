using LibraryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryService.Infrastructure.EntityConfiguration
{
    /// <summary>
    /// Configure entity <see cref="Book"/> to used with EF Core.
    /// </summary>
    public class BookConfiguration
    {
        /// <summary>
        /// Configures the Book entity for Entity Framework using Fluent API.
        /// </summary>
        /// <param name="builder">The entity builder for the Book entity.</param>
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books", "dbo");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("Id");

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("Title");

            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Author");

            builder.Property(b => b.Genre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Genre");

            builder.Property(b => b.ReleaseDate)
                .IsRequired()
                .HasColumnName("Release_Date");

            builder.Property(b => b.Synopsis)
                .HasMaxLength(1000)
                .HasColumnName("Synopsis");
        }
    }
}
