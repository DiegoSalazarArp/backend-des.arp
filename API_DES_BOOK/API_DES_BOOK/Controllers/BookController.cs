using API_DES_BOOK.Models;
using API_DES_BOOK.Models.Entities;
using API_DES_BOOK.Models.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace API_DES_BOOK.Controllers
{
    /// <summary>
    /// API controller for book-related operations.
    /// </summary>
    /// [Authorize]
    public class BookController : ApiController
    {
        /// <summary>
        /// Retrieves all books from the database.
        /// </summary>
        /// <returns>An <see cref="IHttpActionResult"/> containing the list of books.</returns>
        [HttpGet]
        [ResponseType(typeof(OutputBookController))]
        public IHttpActionResult GetAllBooks()
        {
            try
            {
                var sql = new SqlBD(SqlBD.ControllerName.Book);
                var response = sql.getBooks();
                SqlBD.CloseSqlBd();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a book by ID.
        /// </summary>
        /// <param name="id">The ID of the book.</param>
        /// <returns>An <see cref="IHttpActionResult"/> containing the book.</returns>
        [HttpGet]
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBookById(int id)
        {
            try
            {
                var sql = new SqlBD(SqlBD.ControllerName.Book);
                var response = sql.getBookById(id);
                SqlBD.CloseSqlBd();
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new book.
        /// </summary>
        /// <param name="book">The book to create.</param>
        /// <returns>An <see cref="IHttpActionResult"/> containing the created book.</returns>
        [HttpPost]
        [ResponseType(typeof(Book))]
        public IHttpActionResult CreateBook([FromBody] Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest("Book data is null.");
                }

                var sql = new SqlBD(SqlBD.ControllerName.Book);
                var response = sql.createBook(book.Title, book.Author, book.Genre, book.PublishDate);
                SqlBD.CloseSqlBd();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing book.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="book">The updated book data.</param>
        /// <returns>An <see cref="IHttpActionResult"/> containing the updated book.</returns>
        [HttpPut]
        [ResponseType(typeof(Book))]
        public IHttpActionResult UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                if (book == null || id != book.Id)
                {
                    return BadRequest("Invalid book data.");
                }

                var sql = new SqlBD(SqlBD.ControllerName.Book);
                var response = sql.updateBook(id, book.Title, book.Author, book.Genre, book.PublishDate);
                SqlBD.CloseSqlBd();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a book by ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>An <see cref="IHttpActionResult"/> indicating the result of the deletion.</returns>
        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteBook(int id)
        {
            try
            {
                var sql = new SqlBD(SqlBD.ControllerName.Book);
                var response = sql.deleteBook(id);
                SqlBD.CloseSqlBd();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
