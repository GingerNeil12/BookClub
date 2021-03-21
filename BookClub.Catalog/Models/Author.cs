using System;
using System.Collections.Generic;
using System.Linq;

namespace BookClub.Catalog.Models
{
    public class Author
    {
        private List<BookAuthor> _books;

        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName => Name.ToUpperInvariant();

        public virtual IEnumerable<BookAuthor> Books { get { return _books; } }

        public Author()
        {
            _books = new List<BookAuthor>();
        }

        public IEnumerable<Book> Authored()
        {
            return FilterBooksBy(x => x.AuthorType == AuthorType.Author)
                .Select(x => x.Book);
        }

        public IEnumerable<Book> CoAuthored()
        {
            return FilterBooksBy(x => x.AuthorType == AuthorType.CoAuthor)
                .Select(x => x.Book);
        }

        private IEnumerable<BookAuthor> FilterBooksBy(Func<BookAuthor, bool> predicate)
        {
            return _books.Where(predicate);
        }
    }
}
