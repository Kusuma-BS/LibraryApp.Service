using LibraryApp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repository.Interface
{
    public interface IBookDAL
    {
        //This method is used to add books.
        Task<bool> AddBooks(List<Book> books);

        //This method is used to edit the book.
        Task<bool> EditBook(Book mappedBookEntity);

        //This method is used to get book by its id.
        Task<Book> GetBookById(string Id);

        //This method is used to get list of books.
        Task<List<Book>> GetBooks();
    }
}
