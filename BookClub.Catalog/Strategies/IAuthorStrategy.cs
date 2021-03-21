using System.Collections.Generic;
using BookClub.Catalog.Models;

namespace BookClub.Catalog.Strategies
{
    public interface IAuthorStrategy
    {
        bool CanChangeAuthor(IEnumerable<BookAuthor> authors, Author newAuthor);
    }
}
