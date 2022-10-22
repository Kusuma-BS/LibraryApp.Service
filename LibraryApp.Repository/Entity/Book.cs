using System;
using System.Collections.Generic;

namespace LibraryApp.Repository.Entity
{
    public partial class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
    }
}
