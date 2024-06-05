using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_DES_BOOK.Models.Entities
{
    /// <summary>
    /// Represents a book entity with properties for book details.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the book ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the book title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the book author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the book genre.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets the book publish date.
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class from a DataRow.
        /// </summary>
        /// <param name="row">The DataRow containing book data.</param>
        public Book(DataRow row)
        {
            try
            {
                Id = row["id"] != DBNull.Value ? Convert.ToInt32(row["id"]) : 0;
                Title = row["title"] != DBNull.Value ? row["title"].ToString() : "";
                Author = row["author"] != DBNull.Value ? row["author"].ToString() : "";
                Genre = row["genre"] != DBNull.Value ? row["genre"].ToString() : "";
                PublishDate = row["publishDate"] != DBNull.Value ? Convert.ToDateTime(row["publishDate"]) : DateTime.MinValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
