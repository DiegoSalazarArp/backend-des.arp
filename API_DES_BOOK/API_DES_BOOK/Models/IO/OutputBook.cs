using API_DES_BOOK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DES_BOOK.Models.IO
{
    /// <summary>
    /// Represents the output response for books.
    /// </summary>
    public class OutputBook : OutputBookController
    {
        /// <summary>
        /// Gets or sets the list of books.
        /// </summary>
        public List<Book> ListBooks { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputBook"/> class.
        /// </summary>
        public OutputBook()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputBook"/> class with the specified response type and log ID.
        /// </summary>
        /// <param name="resp">The response type.</param>
        /// <param name="ID_LOG">The log ID.</param>
        public OutputBook(ResponseTypeBook resp, int ID_LOG) : base(ResponseTypeBook.NoData)
        {
            OutputBookController output = new OutputBookController(resp, ID_LOG);
            this.CodError = output.CodError;
            this.MsgError = output.MsgError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputBook"/> class with the specified response type and list of books.
        /// </summary>
        /// <param name="resp">The response type.</param>
        /// <param name="books">The list of books.</param>
        public OutputBook(ResponseTypeBook resp, List<Book> books) : base(ResponseTypeBook.NoData)
        {
            OutputBookController output = new OutputBookController(resp);
            this.CodError = output.CodError;
            this.MsgError = output.MsgError;
            this.ListBooks = books;
        }
    }
}
