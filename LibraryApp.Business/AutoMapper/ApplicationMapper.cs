using AutoMapper;
using LibraryApp.Business.Models;
using LibraryApp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.AutoMapper
{
    public class ApplicationMapper :Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookModel>();
            CreateMap<BaseBookModel, Book>();
            CreateMap<BookModel, Book>();
        }
    }
}
