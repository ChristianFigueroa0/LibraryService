using LibraryService.Domain.Entities;

namespace LibraryService.Domain.Repositories
{
    /// <summary>
    /// Define the methods for books repository.
    /// </summary>
    public interface IBooksRepository
    {
        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns>Collection with <see cref="Book"/>.</returns>
        Task<IEnumerable<Book>> GetAll();
        /// <summary>
        /// Get book by id.
        /// </summary>
        /// <param name="id">The book id.</param>
        /// <returns>Instance of <see cref="Book"/>.</returns>
        Task<Book> Get(int id);
        /// <summary>
        /// Update book.
        /// </summary>
        /// <param name="book">Book to update.</param>
        /// <returns>The update book.</returns>
        Task<Book> Update(Book book);
        /// <summary>
        /// Remove book.
        /// </summary>
        /// <param name="id">The book id to remove.</param>
        /// <returns>True if the book was removed successfull, false another case.</returns>
        Task<bool> Remove(int id);
        /// <summary>
        /// Create a new book.
        /// </summary>
        /// <param name="book">Book data.</param>
        /// <returns>True if the book was created successfull, false another case.</returns>
        Task<bool> Create(Book book);
    }
}
