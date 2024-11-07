using LibraryService.Domain.Repositories;

namespace LibraryService.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of <see cref="IUnitOfWork"/>.
    /// </summary>
    /// <param name="booksRepository">Injected <see cref="IBooksRepository"/>.</param>
    public class UnitOfWork(IBooksRepository booksRepository) : IUnitOfWork
    {
        /// <summary>
        /// Books repository.
        /// </summary>
        private readonly IBooksRepository _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
        /// <summary>
        /// Public books reposority.
        /// </summary>
        public IBooksRepository BooksRepository => _booksRepository;
    }
}
