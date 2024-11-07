namespace LibraryService.Domain.Repositories
{
    /// <summary>
    /// Define the methodos for Unit of work.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Books repository.
        /// </summary>
        public IBooksRepository BooksRepository { get; }
    }
}
