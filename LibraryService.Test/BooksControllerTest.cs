using LibraryService.Application.Dtos;
using LibraryService.Application.Services;
using LibraryService.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LibraryService.Test
{
    /// <summary>
    /// Class to test <see cref="BooksController"/>.
    /// </summary>
    public class BooksControllerTests
    {
        /// <summary>
        /// Mock <see cref="IBooksService"/>.
        /// </summary>
        private readonly Mock<IBooksService> _mockBooksService;
        /// <summary>
        /// Class to test.
        /// </summary>
        private readonly BooksController _controller;

        /// <summary>
        /// Constructor class.
        /// </summary>
        public BooksControllerTests()
        {
            _mockBooksService = new Mock<IBooksService>();
            _controller = new BooksController(_mockBooksService.Object);
        }
        /// <summary>
        /// Ensure that index return correct view result.
        /// </summary>
        /// <returns><see cref="Task"/>.</returns>
        [Fact]
        public async Task Index_Returns_ViewResult_With_ListOfBooks()
        {
            // Arrange
            var books = new List<BookDto>
            {
                new BookDto { Id = 1, Title = "Book 1" },
                new BookDto { Id = 2, Title = "Book 2" }
            };
            _mockBooksService.Setup(service => service.GetAll()).ReturnsAsync(books);

            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<BookDto>>(viewResult.Model);
            Assert.Equal(2, model.Count);
        }
        /// <summary>
        /// Ensure that create get returns the correct partial view.
        /// </summary>
        /// <returns><see cref="Task"/>.</returns>
        [Fact]
        public async Task Create_Get_Returns_PartialView()
        {
            // Act
            var result = await _controller.Create();

            // Assert
            var partialViewResult = Assert.IsType<Microsoft.AspNetCore.Mvc.PartialViewResult>(result);
            Assert.Equal("_Create", partialViewResult.ViewName);
        }
        /// <summary>
        /// Ensure that create post calls service and returns Ok result.
        /// </summary>
        /// <returns><see cref="Task"/>.</returns>
        [Fact]
        public async Task Create_Post_Calls_Create_On_Service_And_Returns_OkResult()
        {
            // Arrange
            var bookDto = new BookDto { Title = "New Book", Author = "Author" };

            // Act
            var result = await _controller.Create(bookDto);

            // Assert
            _mockBooksService.Verify(service => service.Create(bookDto), Times.Once);
            Assert.IsType<OkResult>(result);
        }
        /// <summary>
        /// Ensure that update get returns correct partial view with book data.
        /// </summary>
        /// <returns><see cref="Task"/>.</returns>
        [Fact]
        public async Task Update_Get_Returns_PartialView_With_Book()
        {
            // Arrange
            var book = new BookDto { Id = 1, Title = "Book 1" };
            _mockBooksService.Setup(service => service.Get(It.IsAny<int>())).ReturnsAsync(book);

            // Act
            var result = await _controller.Update(1);

            // Assert
            var partialViewResult = Assert.IsType<Microsoft.AspNetCore.Mvc.PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<BookDto>(partialViewResult.Model);
            Assert.Equal("Book 1", model.Title);
        }
        /// <summary>
        /// Ensure that update post calls service and returns Ok result.
        /// </summary>
        /// <returns><see cref="Task"/>.</returns>
        [Fact]
        public async Task Update_Post_Calls_Update_On_Service_And_Returns_OkResult()
        {
            // Arrange
            var bookDto = new BookDto { Id = 1, Title = "Updated Book", Author = "Updated Author" };

            // Act
            var result = await _controller.Update(bookDto);

            // Assert
            _mockBooksService.Verify(service => service.Update(bookDto), Times.Once);
            Assert.IsType<OkResult>(result);
        }
        /// <summary>
        /// Ensure that get delete confirmation returns the correct partial view.
        /// </summary>
        /// <returns><see cref="Task"/>.</returns>
        [Fact]
        public async Task GetDeleteConfirmation_Returns_PartialView()
        {
            // Act
            var result = await _controller.GetDeleteConfirmation(1);

            // Assert
            var partialViewResult = Assert.IsType<Microsoft.AspNetCore.Mvc.PartialViewResult>(result);
            Assert.Equal("_DeleteConfirmation", partialViewResult.ViewName);
        }
        /// <summary>
        /// Ensure that delete post calls remove on service and returns Ok result.
        /// </summary>
        /// <returns><see cref="Task"/>.</returns>
        [Fact]
        public async Task Delete_Post_Calls_Remove_On_Service_And_Returns_OkResult()
        {
            // Act
            var result = await _controller.Delete(1);

            // Assert
            _mockBooksService.Verify(service => service.Remove(1), Times.Once);
            Assert.IsType<OkResult>(result);
        }
        /// <summary>
        /// Ensure that details returns correct partial view with book data.
        /// </summary>
        /// <returns><see cref="Task"/>.</returns>
        [Fact]
        public async Task Details_Returns_PartialView_With_Book()
        {
            // Arrange
            var book = new BookDto { Id = 1, Title = "Book 1", Author = "Author 1" };
            _mockBooksService.Setup(service => service.Get(It.IsAny<int>())).ReturnsAsync(book);

            // Act
            var result = await _controller.Details(1);

            // Assert
            var partialViewResult = Assert.IsType<Microsoft.AspNetCore.Mvc.PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<BookDto>(partialViewResult.Model);
            Assert.Equal("Book 1", model.Title);
        }
    }
}
