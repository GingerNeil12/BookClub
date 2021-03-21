using System.Collections.Generic;
using System.Linq;
using BookClub.Catalog.Models;

namespace BookClub.Catalog.Strategies.Implementations
{
    public class AuthorStrategy : IAuthorStrategy
    {
        public bool CanChangeAuthor(IEnumerable<BookAuthor> authors, Author newAuthor)
        {
            return !FilterAuthorsByName
            (
                authors,
                newAuthor.NormalizedName
            ).Any();
        }

        private static IEnumerable<BookAuthor> FilterAuthorsByName
        (
            IEnumerable<BookAuthor> authors,
            string name
        )
        {
            return authors.Where(x => x.Author.NormalizedName == name);
        }
    }
}
