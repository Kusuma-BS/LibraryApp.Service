using LibraryApp.Repository.Entity;
using LibraryApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repository.Implementation
{
    public class BookDAL : IBookDAL
    {
        private readonly BookDbContext dbContext;
        public BookDAL(BookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// This method is used to add books.
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public async Task<bool> AddBooks(List<Book> books)
        {
            await dbContext.Books.AddRangeAsync(books);
            var noOfAffeted = await dbContext.SaveChangesAsync();
            return noOfAffeted > 0;
        }

        /// <summary>
        /// This method is used to modify the book information.
        /// </summary>
        /// <param name="mappedEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> EditBook(Book mappedBookEntity)
        {
            dbContext.Books.UpdateRange(mappedBookEntity);
            var noOfAffeted = await dbContext.SaveChangesAsync();
            return noOfAffeted > 0;

        }

        /// <summary>
        /// This method is used to get book by its id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Book> GetBookById(string Id)
        {
            var Book = await dbContext.Books.Where(book => book.Id.ToString() == Id).AsNoTracking().FirstOrDefaultAsync();
            return Book;
        }

        /// <summary>
        /// This method is used to get list of books.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Book>> GetBooks()
        {
            var Books = await dbContext.Books.ToListAsync();
            return Books;
        }
    }
}
