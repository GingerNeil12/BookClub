using System;
using System.Collections.Generic;
using System.Linq;

namespace BookClub.Catalog.Models
{
    public class Author : AuditableEntity
    {
        private ICollection<BookAuthor> _bookAuthors;

        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName => Name.ToUpperInvariant();

        public virtual IEnumerable<BookAuthor> BookAuthors { get { return _bookAuthors; } }

        public Author()
        {
            _bookAuthors = new List<BookAuthor>();
        }

        public IEnumerable<Book> Books()
        {
            return _bookAuthors.Select(x => x.Book);
        }
    }
}
