using System.Collections.Generic;
using BookClub.Catalog.Models;

namespace BookClub.Catalog.Strategies
{
    public interface IBookAuthorStrategy
    {
        bool CanAddAuthor(IEnumerable<BookAuthor> bookAuthors, Author author);
        bool CanRemoveAuthor(IEnumerable<BookAuthor> bookAuthors, int id);
    }
}
