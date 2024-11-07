using LibraryService.Application.Dtos;
using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Services
{
    /// <summary>
    /// Define methods of book service.
    /// </summary>
    public interface IBooksService
    {
        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns>Collection with <see cref="BookDto"/>.</returns>
        Task<IEnumerable<BookDto>> GetAll();
        /// <summary>
        /// Get book by id.
        /// </summary>
        /// <param name="id">The book id.</param>
        /// <returns>Instance of <see cref="Book"/>.</returns>
        Task<BookDto> Get(int id);
        /// <summary>
        /// Update book.
        /// </summary>
        /// <param name="book">Book to update.</param>
        /// <returns>The update book.</returns>
        Task<BookDto> Update(BookDto book);
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
        Task<bool> Create(BookDto book);
    }
}
