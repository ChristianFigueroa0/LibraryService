using LibraryService.Application.Dtos;
using LibraryService.Application.Services;
using LibraryService.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Web.Controllers
{
    /// <summary>
    /// Handle all request related to Books.
    /// </summary>
    /// <param name="booksService">Injected <see cref="IBooksService"/>.</param>
    public class BooksController(IBooksService booksService) : Controller
    {
        /// <summary>
        /// Book service.
        /// </summary>
        private readonly IBooksService _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
        /// <summary>
        /// Show all books.
        /// </summary>
        /// <returns>Index view.</returns>
        public async Task<IActionResult> Index()
        {
            var books = await _booksService.GetAll();
            return View(books);
        }
        /// <summary>
        /// Show modal to create new book.
        /// </summary>
        /// <returns>Partial view with form to create a new book.</returns>
        [HttpGet]
        [Route("books/Create")]
        public async Task<IActionResult> Create() => await Task.FromResult(PartialView("_Create"));
        /// <summary>
        /// Create a new book.
        /// </summary>
        /// <param name="model">Book data.</param>
        /// <returns>Ok response.</returns>
        [HttpPost]
        [Route("books/Create")]
        public async Task<IActionResult> Create([FromForm] BookDto model)
        {
            await _booksService.Create(model);
            return Ok();
        }
        /// <summary>
        /// Show modal to update book
        /// </summary>
        /// <param name="id">The id of the book to update.</param>
        /// <returns>Partial view with form to update a book.</returns>
        [HttpGet]
        [Route("books/Update/{id:int}")]
        public async Task<IActionResult> Update(int id)
        {
            var book = await _booksService.Get(id);
            return PartialView("_Update", book);
        }
        /// <summary>
        /// Update book.
        /// </summary>
        /// <param name="model">New book data.</param>
        /// <returns>Ok response.</returns>
        [HttpPost]
        [Route("books/Update/")]
        public async Task<IActionResult> Update([FromForm] BookDto model)
        {
            await _booksService.Update(model);
            return Ok();
        }
        /// <summary>
        /// Show delete confirmation modal.
        /// </summary>
        /// <param name="id">Book id.</param>
        /// <returns>Partial view with confirmation message.</returns>
        [HttpGet]
        [Route("books/Delete/{id:int}")]
        public async Task<IActionResult> GetDeleteConfirmation(int id) => await Task.FromResult(PartialView("_DeleteConfirmation", id));
        /// <summary>
        /// Delete book.
        /// </summary>
        /// <param name="id">Book id to delete.</param>
        /// <returns>Ok response.</returns>
        [Route("books/Delete/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _booksService.Remove(id);
            return Ok();
        }
        /// <summary>
        /// Show details of book.
        /// </summary>
        /// <param name="id">Book id.</param>
        /// <returns>Partial view with modal in readonly.</returns>
        [Route("books/Details/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var book = await _booksService.Get(id);
            return PartialView("_Details", book);
        }
    }
}
