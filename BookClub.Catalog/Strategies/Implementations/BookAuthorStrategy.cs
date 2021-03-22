using System.Collections.Generic;
using System.Linq;
using BookClub.Catalog.Models;

namespace BookClub.Catalog.Strategies.Implementations
{
    public class BookAuthorStrategy : IBookAuthorStrategy
    {
        public bool CanAddAuthor
        (
            IEnumerable<BookAuthor> bookAuthors,
            Author author
        )
        {
            return !bookAuthors
                .Where(x => x.Author.NormalizedName == author.NormalizedName)
                .Any();
        }

        public bool CanRemoveAuthor
        (
            IEnumerable<BookAuthor> bookAuthors,
            int id
        )
        {
            return AuthorCountAboveOne(bookAuthors)
                && AuthorIdContainedWithinCollection(bookAuthors, id);
        }

        private static bool AuthorCountAboveOne(IEnumerable<BookAuthor> bookAuthors)
        {
            return bookAuthors.Count() > 1;
        }

        private static bool AuthorIdContainedWithinCollection
        (
            IEnumerable<BookAuthor> bookAuthors,
            int id
        )
        {
            return bookAuthors.Where(x => x.AuthorId == id).Any();
        }
    }
}
