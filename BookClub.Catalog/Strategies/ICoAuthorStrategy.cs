using System.Collections.Generic;
using BookClub.Catalog.Models;

namespace BookClub.Catalog.Strategies
{
    public interface ICoAuthorStrategy
    {
        bool CanAddCoAuthor(IEnumerable<BookAuthor> authors, Author newCoAuthor);
        bool CanRemoveCoAuthor(IEnumerable<BookAuthor> authors, int id);
    }
}
