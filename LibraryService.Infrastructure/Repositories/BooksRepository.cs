using LibraryService.Domain.Entities;
using LibraryService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of <see cref="IBooksRepository"/>.
    /// </summary>
    /// <param name="context">Injected <see cref="DatabaseContext"/>.</param>
    public class BooksRepository(DatabaseContext context) : IBooksRepository
    {
        /// <summary>
        /// Database context allows access to database.
        /// </summary>
        private readonly DatabaseContext _databaseContext = context ?? throw new ArgumentNullException(nameof(context));
        /// <summary>
        /// Create a new book.
        /// </summary>
        /// <param name="book">Book data.</param>
        /// <returns>True if the book was created successfull, false another case.</returns>
        public async Task<bool> Create(Book book)
        {
            _databaseContext.Books.Add(book);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Get book by id.
        /// </summary>
        /// <param name="id">The book id.</param>
        /// <returns>Instance of <see cref="Book"/>.</returns>
        public async Task<Book> Get(int id) =>
            await _databaseContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns>Collection with <see cref="Book"/>.</returns>
        public async Task<IEnumerable<Book>> GetAll()
            => await _databaseContext.Books.AsNoTracking().ToListAsync();
        /// <summary>
        /// Update book.
        /// </summary>
        /// <param name="book">Book to update.</param>
        /// <returns>The update book.</returns>
        public async Task<bool> Remove(int id)
        {
            await _databaseContext.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return true;
        }
        /// <summary>
        /// Remove book.
        /// </summary>
        /// <param name="id">The book id to remove.</param>
        /// <returns>True if the book was removed successfull, false another case.</returns>
        public async Task<Book> Update(Book book)
        {
            _databaseContext.Books
                .Update(book);

            await _databaseContext.SaveChangesAsync();

            return book;
        }
    }
}
