using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DES_BOOK.Models.IO
{
    /// <summary>
    /// Controller for book output responses.
    /// </summary>
    public class OutputBookController
    {

        /// <summary>
        /// Enum representing the type of book response.
        /// </summary>
        public enum ResponseTypeBook
        {
            /// <summary>
            /// Response type for successful operation.
            /// </summary>
            Ok = 0,


            /// <summary>
            /// Response type for no info (initial).
            /// </summary>
            NoData = 1,


            /// <summary>
            /// Response type for book not found.
            /// </summary>
            NotFound = 2,

        }

        /// <summary>
        /// Gets or sets the response type code.
        /// </summary>
        public ResponseTypeBook CodError { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string MsgError { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputBookController"/> class.
        /// </summary>
        public OutputBookController()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputBookController"/> class with the specified error code and log ID.
        /// </summary>
        /// <param name="CodError">The response type code.</param>
        /// <param name="ID_LOG">The optional log ID.</param>
        public OutputBookController(ResponseTypeBook CodError, int ID_LOG = 0)
        {
            this.CodError = CodError;
            switch (CodError)
            {
                case ResponseTypeBook.Ok:
                    MsgError = "OK";
                    break;
                case ResponseTypeBook.NoData:
                    MsgError = "No data";
                    break;
                case ResponseTypeBook.NotFound:
                    MsgError = "Book not found";
                    break;
                default:
                    MsgError = "Execution error";
                    break;
            }

            MsgError = ID_LOG != 0 ? MsgError + " - ID_LOGERROR: " + ID_LOG : MsgError;
        }

    }
}