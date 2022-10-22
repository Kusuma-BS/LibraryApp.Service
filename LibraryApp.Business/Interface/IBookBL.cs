using LibraryApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Interface
{
    public interface IBookBL
    {
        //This method is used to add books.
        Task<bool> AddBooks(List<BaseBookModel> book);

        //This method is used to modify the book.
        Task<bool> EditBook(BookModel book);

        //This method is used to get book by its id.
        Task<BookModel> GetBookById(string Id);

        //This method is used to get list of books.
        Task<List<BookModel>> GetBooks();
    }
}
