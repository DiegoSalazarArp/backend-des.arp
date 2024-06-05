using API_DES_BOOK.Models.Entities;
using API_DES_BOOK.Models.IO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API_DES_BOOK.Models
{
    /// <summary>
    /// Provides methods for interacting with the SQL database.
    /// </summary>
    public class SqlBD
    {
        /// <summary>
        /// Enum representing the controller names.
        /// </summary>
        public enum ControllerName
        {
            /// <summary>
            /// Book controller.
            /// </summary>
            Book = 0,
        }

        /// <summary>
        /// Static SQL connection.
        /// </summary>
        private static SqlConnection sqlCnn = new SqlConnection();

        /// <summary>
        /// Connection string for the SQL connection.
        /// </summary>
        private static string ConnectionString = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlBD"/> class with the specified controller name.
        /// </summary>
        /// <param name="controllerName">The controller name.</param>
        public SqlBD(ControllerName controllerName)
        {
            switch (controllerName)
            {
                case ControllerName.Book:
                    ConnectionString = ConfigurationManager.ConnectionStrings["book"].ConnectionString;
                    break;
                default:
                    ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
                    break;
            }
            OpenSqlBD();
        }

        /// <summary>
        /// Opens the SQL database connection.
        /// </summary>
        /// <returns>True if the connection is opened successfully, otherwise throws an exception.</returns>
        public static bool OpenSqlBD()
        {
            try
            {
                sqlCnn = new SqlConnection(ConnectionString);
                sqlCnn.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Close the SQL database connection.
        /// </summary>
        public static void CloseSqlBd()
        {
            sqlCnn.Dispose();
        }

        /// <summary>
        /// Retrieves the list of books from the database.
        /// </summary>
        /// <returns>An <see cref="OutputBook"/> containing the list of books and the response type.</returns>
        public OutputBook getBooks()
        {
            DataTable dt = new DataTable();
            var DbCodError = OutputBookController.ResponseTypeBook.NoData;
            var listBook = new List<Book>();

            try
            {
                if (sqlCnn.State != ConnectionState.Open)
                {
                    sqlCnn.Open();
                }

                SqlCommand cdm = new SqlCommand("[dbo].[sp_GetBooks]", sqlCnn)
                {
                    CommandType = CommandType.StoredProcedure
                };


                var da = new SqlDataAdapter(cdm);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                if (dt.Rows.Count == 0)
                {
                    return new OutputBook();
                }

                foreach (DataRow row in dt.Rows)
                {
                    var book = new Book(row);
                    listBook.Add(book);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            DbCodError = OutputBookController.ResponseTypeBook.Ok;
            return new OutputBook(DbCodError, listBook);
        }


        /// <summary>
        /// Retrieves a book by ID from the database.
        /// </summary>
        /// <param name="id">The ID of the book.</param>
        /// <returns>The book with the specified ID.</returns>
        public OutputBookById getBookById(int id)
        {
            DataTable dt = new DataTable();
            var DbCodError = OutputBookController.ResponseTypeBook.NoData;
            Book book = null;

            try
            {
                if (sqlCnn.State != ConnectionState.Open)
                {
                    sqlCnn.Open();
                }

                SqlCommand cmd = new SqlCommand("[dbo].[sp_GetBookById]", sqlCnn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Id", id));

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    book = new Book(dt.Rows[0]);
                }
                DbCodError = OutputBookController.ResponseTypeBook.Ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new OutputBookById(DbCodError, book);
        }

        /// <summary>
        /// Creates a new book in the database.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="genre">The genre of the book.</param>
        /// <param name="publishDate">The publish date of the book.</param>
        public OutputBookController createBook(string title, string author, string genre, DateTime publishDate)
        {
            var DbCodError = OutputBookController.ResponseTypeBook.NoData;

            try
            {
                if (sqlCnn.State != ConnectionState.Open)
                {
                    sqlCnn.Open();
                }

                SqlCommand cmd = new SqlCommand("[dbo].[sp_CreateBook]", sqlCnn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Title", title));
                cmd.Parameters.Add(new SqlParameter("@Author", author));
                cmd.Parameters.Add(new SqlParameter("@Genre", genre));
                cmd.Parameters.Add(new SqlParameter("@PublishDate", publishDate));

                cmd.ExecuteNonQuery();
                DbCodError = OutputBookController.ResponseTypeBook.Ok;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new OutputBookController(DbCodError);

        }

        /// <summary>
        /// Updates an existing book in the database.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="title">The new title of the book.</param>
        /// <param name="author">The new author of the book.</param>
        /// <param name="genre">The new genre of the book.</param>
        /// <param name="publishDate">The new publish date of the book.</param>
        public OutputBookController updateBook(int id, string title, string author, string genre, DateTime publishDate)
        {
            var DbCodError = OutputBookController.ResponseTypeBook.NoData;

            try
            {
                if (sqlCnn.State != ConnectionState.Open)
                {
                    sqlCnn.Open();
                }

                SqlCommand cmd = new SqlCommand("[dbo].[sp_UpdateBook]", sqlCnn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.Parameters.Add(new SqlParameter("@Title", title));
                cmd.Parameters.Add(new SqlParameter("@Author", author));
                cmd.Parameters.Add(new SqlParameter("@Genre", genre));
                cmd.Parameters.Add(new SqlParameter("@PublishDate", publishDate));

                cmd.ExecuteNonQuery();
                DbCodError = OutputBookController.ResponseTypeBook.Ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new OutputBookController(DbCodError);

        }

        /// <summary>
        /// Deletes a book by ID from the database.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        public OutputBookController deleteBook(int id)
        {
            var DbCodError = OutputBookController.ResponseTypeBook.NoData;

            try
            {
                if (sqlCnn.State != ConnectionState.Open)
                {
                    sqlCnn.Open();
                }

                SqlCommand cmd = new SqlCommand("[dbo].[sp_DeleteBook]", sqlCnn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@Id", id));

                cmd.ExecuteNonQuery();
                DbCodError = OutputBookController.ResponseTypeBook.Ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new OutputBookController(DbCodError);
        }
    }
}
