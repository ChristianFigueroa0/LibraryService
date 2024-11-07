using LibraryService.Application.Dtos;
using LibraryService.Domain.Entities;
using LibraryService.Domain.Repositories;

namespace LibraryService.Application.Services
{
    /// <summary>
    /// Implementation of <see cref="IBooksService"/>.
    /// </summary>
    /// <param name="unitOfWork">Injected <see cref="IUnitOfWork"/>.</param>
    public class BooksService(IUnitOfWork unitOfWork) : IBooksService
    {
        /// <summary>
        /// Unit of work for access to data.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        /// <summary>
        /// Create a new book.
        /// </summary>
        /// <param name="book">Book data.</param>
        /// <returns>True if the book was created successfull, false another case.</returns>
        public async Task<bool> Create(BookDto book)
        {
            var newBook = new Book
            {
                Author = book.Author,
                Title = book.Title,
                Genre = book.Genre,
                ReleaseDate = book.ReleaseDate,
                Synopsis = book.Synopsis
            };

            await _unitOfWork.BooksRepository.Create(newBook);

            return true;
        }
        /// <summary>
        /// Get book by id.
        /// </summary>
        /// <param name="id">The book id.</param>
        /// <returns>Instance of <see cref="Book"/>.</returns>
        public async Task<BookDto> Get(int id)
        {
            var book = await _unitOfWork.BooksRepository.Get(id);
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                ReleaseDate = book.ReleaseDate,
                Synopsis = book.Synopsis
            };
        }
        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns>Collection with <see cref="BookDto"/>.</returns>
        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var books = await _unitOfWork.BooksRepository
                .GetAll();

            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Genre = b.Genre,
                ReleaseDate = b.ReleaseDate,
                Synopsis = b.Synopsis
            });
        }
        /// <summary>
        /// Remove book.
        /// </summary>
        /// <param name="id">The book id to remove.</param>
        /// <returns>True if the book was removed successfull, false another case.</returns>
        public async Task<bool> Remove(int id)
            => await _unitOfWork.BooksRepository.Remove(id);
        /// <summary>
        /// Update book.
        /// </summary>
        /// <param name="book">Book to update.</param>
        /// <returns>The update book.</returns>
        public async Task<BookDto> Update(BookDto book)
        {
            var updatedBook = new Book
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                ReleaseDate = book.ReleaseDate,
                Synopsis = book.Synopsis
            };

            await _unitOfWork.BooksRepository.Update(updatedBook);

            return book;
        }
    }
}
