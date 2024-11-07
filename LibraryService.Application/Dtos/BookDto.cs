using System.ComponentModel.DataAnnotations;

namespace LibraryService.Application.Dtos
{
    /// <summary>
    /// Book dto.
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// Unique identifier for the book.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The title of the book.
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// The author of the book.
        /// </summary>
        [Required]
        public string Author { get; set; }
        /// <summary>
        /// The genre of the book.
        /// </summary>
        [Required]
        public string Genre { get; set; }
        /// <summary>
        /// The publication date of the book.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// The synopsis of the book.
        /// </summary>
        [Required]
        public string Synopsis { get; set; }
    }
}
