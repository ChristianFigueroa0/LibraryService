using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    /// <summary>
    /// Represents the book entity.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Unique identifier for the book.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The title of the book.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The author of the book.
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// The genre of the book.
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// The publication date of the book.
        /// </summary>
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// The synopsis of the book.
        /// </summary>
        public string Synopsis { get; set; }
    }
}
