using LibraryApp.Business.Interface;
using LibraryApp.Business.Models;
using LibraryApp.Service.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Xunit;

namespace LibraryApp.Test
{
    public class BookControllerTest
    {
        private readonly Mock<IBookBL> bookBLmock;
        private readonly Mock<ILogger> loggerMock;
        public BookControllerTest()
        {
            bookBLmock = new Mock<IBookBL>();
            loggerMock = new Mock<ILogger>();
        }

        [Fact]
        public void GetBooks()
        {
            List<BookModel> bookModels = new List<BookModel>
            {
                new BookModel
                {
                    AuthorName="ABCD",
                    Id="12333",
                    Name="Name"
                },
            };
            var controller = new BookController(bookBLmock.Object, (ILogger<BookController>)loggerMock.Object);
            bookBLmock.Setup(bal => bal.GetBooks()).ReturnsAsync(bookModels);
            var result = controller.GetBooks();
            Assert.NotNull(result);
            bookBLmock.Verify(bal => bal.GetBooks(),Times.Once());
        }

        [Fact]
        public void GetBooksById()
        {
            BookModel bookModels = new BookModel
            {
                    AuthorName="ABCD",
                    Id="12333",
                    Name="Name"
            };
            var controller = new BookController(bookBLmock.Object, (ILogger<BookController>)loggerMock.Object);
            bookBLmock.Setup(bal => bal.GetBookById("12333")).ReturnsAsync(bookModels);
            var result = controller.GetBookById("12333");
            Assert.NotNull(result);
            bookBLmock.Verify(bal => bal.GetBookById("12333"), Times.Once());
        }
    }
}