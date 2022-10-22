using LibraryApp.Business.Interface;
using LibraryApp.Business.Models;
using LibraryApp.Service.ApplicationMessages;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Service.Controllers
{
    [Route("api/Book")]
    public class BookController : Controller
    {
        private readonly IBookBL bookBL;
        private readonly ILogger<BookController> booklogger;
        public BookController(IBookBL bookBL, ILogger<BookController> booklogger)
        {
            this.bookBL = bookBL;
            this.booklogger = booklogger;
        }

        /// <summary>
        /// This method is used to get list of books.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetBooks()
        {
            booklogger.LogInformation("Entering GetBooks");
            var Books = await bookBL.GetBooks();
            return Ok(Books);
        }

        /// <summary>
        /// This method is used to get book by its id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/Id")]
        public async Task<IActionResult> GetBookById(string Id)
        {
            booklogger.LogInformation("Entering GetBookById");
            var Books = await bookBL.GetBookById(Id);
            return Ok(Books);
        }

        /// <summary>
        /// This method is used to add books
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddBook")]
        public async Task<IActionResult> AddBooks([FromBody] List<BaseBookModel> book)
        {
            booklogger.LogInformation("Entering AddBooks");
            var AddBook = await bookBL.AddBooks(book);
            if(AddBook)
            {
                ApplicationMessage success = new ApplicationMessage("Books Added Successfully.");
                return Created("~/api/Book/AddBook", success);
            }
            else
            {
                ApplicationMessage failure = new ApplicationMessage("Failed to add books.");
                return BadRequest(failure);
            }
        }

        /// <summary>
        /// This method is used to modify the book.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("EditBook")]
        public async Task<IActionResult> EditBook([FromBody] BookModel book)
        {
            booklogger.LogInformation("Entering EditBook");
            var EditBook = await bookBL.EditBook(book);
            if (EditBook)
            {
                ApplicationMessage success = new ApplicationMessage("Book modified Successfully.");
                return Ok(success);
            }
            else
            {
                ApplicationMessage failure = new ApplicationMessage("Failed to modify book.");
                return BadRequest(failure);
            }
        }

    }
}
