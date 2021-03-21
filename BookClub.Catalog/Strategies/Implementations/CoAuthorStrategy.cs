using System;
using System.Collections.Generic;
using System.Linq;
using BookClub.Catalog.Models;

namespace BookClub.Catalog.Strategies.Implementations
{
    public class CoAuthorStrategy : ICoAuthorStrategy
    {
        public bool CanAddCoAuthor
        (
            IEnumerable<BookAuthor> authors,
            Author newCoAuthor
        )
        {
            return !FilterAuthorsBy
            (
                authors,
                x => x.Author.NormalizedName == newCoAuthor.NormalizedName
            )
            .Any();
        }

        public bool CanRemoveCoAuthor
        (
            IEnumerable<BookAuthor> authors,
            int id
        )
        {
            return FilterAuthorsBy
            (
                authors,
                x => x.AuthorId == id && x.AuthorType == AuthorType.CoAuthor
            )
            .Any();
        }

        private static IEnumerable<BookAuthor> FilterAuthorsBy
        (
            IEnumerable<BookAuthor> authors,
            Func<BookAuthor, bool> predicate
        )
        {
            return authors.Where(predicate);
        }
    }
}
