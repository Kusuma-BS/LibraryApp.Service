using AutoMapper;
using LibraryApp.Business.Interface;
using LibraryApp.Business.Models;
using LibraryApp.Repository.Entity;
using LibraryApp.Repository.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Implementation
{
    public class BookBL :IBookBL
    {
        private readonly IBookDAL bookDAL;
        private readonly IMapper mapper;
        private readonly ILogger<BookBL> bookBLlogger;
        public BookBL(IBookDAL bookDAL, IMapper mapper, ILogger<BookBL> bookBLlogger)
        {
            this.bookDAL = bookDAL;
            this.mapper = mapper;
            this.bookBLlogger = bookBLlogger;
        }

        public async Task<bool> AddBooks(List<BaseBookModel> book)
        {
            bookBLlogger.LogInformation("Entering AddBooks BL");
            var AddBooks = await bookDAL.AddBooks(mapper.Map<List<Book>>(book));
            return AddBooks;
        }

        /// <summary>
        /// This method is used to edit the book.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<bool> EditBook(BookModel book)
        {
            bookBLlogger.LogInformation("Entering EditBook BL");
            var ExistedBook = await GetBookById(book.Id);
            var mappedBookEntity = mapper.Map<Book>(book);
            var EditBook = await bookDAL.EditBook(mappedBookEntity);
            return EditBook;
        }

        /// <summary>
        /// This method is used to get book by its id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<BookModel> GetBookById(string Id)
        {
            bookBLlogger.LogInformation("Entering GetBookById BL");
            var Book = await bookDAL.GetBookById(Id);
            if(Book == null)
            {
                throw new NullReferenceException("Book Id not found in Database, Please provide valid Id.");
            }
            return(mapper.Map<BookModel>(Book));
        }

        /// <summary>
        /// This method is used to get list of books.
        /// </summary>
        /// <returns></returns>
        public async Task<List<BookModel>> GetBooks()
        {
            bookBLlogger.LogInformation("Entering GetBooks BL");
            var Books = await bookDAL.GetBooks();
            bookBLlogger.LogInformation("Fetched Book deatils from database:", Books.Count);
            return (mapper.Map<List<BookModel>>(Books));
        }
    }
}
