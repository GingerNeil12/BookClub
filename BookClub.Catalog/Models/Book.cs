using System;
using System.Collections.Generic;
using System.Linq;
using BookClub.Catalog.Strategies;

namespace BookClub.Catalog.Models
{
    public class Book
    {
        private Genre _genre;
        private List<BookAuthor> _authors;
        private List<Tag> _tags;

        private int _genreId;

        public int Id { get; set; }
        public string Title { get; set; }
        public string NormalizedTitle => Title.ToUpperInvariant();
        public string Synopsis { get; set; }
        public string ISBN { get; set; }
        public bool NonFiction { get; set; }
        public bool HardBack { get; set; }
        public int GenreId { get { return _genreId; } }
        public int? Edition { get; set; }
        public int? PageCount { get; set; }
        public DateTime? PublishedOn { get; set; }

        public virtual Genre Genre { get { return _genre; } }
        public virtual IEnumerable<BookAuthor> Authors { get { return _authors; } }
        public virtual IEnumerable<Tag> Tags { get { return _tags; } }

        /// <summary>
        /// Left for use by EF
        /// </summary>
        public Book()
        {

        }

        /// <summary>
        /// Initializes a Book with the providied Author and Genre.
        /// </summary>
        /// <param name="author">The main author.</param>
        /// <param name="genre">The genre.</param>
        public Book(Author author, Genre genre)
        {
            _authors = new List<BookAuthor>()
            {
                new BookAuthor(author, this, AuthorType.Author)
            };
            _tags = new List<Tag>();
            _genre = genre;
            _genreId = genre.Id;
        }

        public Author Author()
        {
            return FilterAuthorsBy(x => x.AuthorType == AuthorType.Author)
                .Select(x => x.Author)
                .First();
        }

        public IEnumerable<Author> CoAuthors()
        {
            return FilterAuthorsBy(x => x.AuthorType == AuthorType.CoAuthor)
                .OrderBy(x => x.Author.NormalizedName)
                .Select(x => x.Author);
        }

        public void ChangeAuthor
        (
            IAuthorStrategy authorStrategy,
            Author newAuthor
        )
        {
            if (authorStrategy.CanChangeAuthor(_authors, newAuthor))
            {
                var currentAuthor = FilterAuthorsBy(x => x.AuthorType == AuthorType.Author)
                    .First();

                _authors.Remove(currentAuthor);

                _authors.Add(new BookAuthor(newAuthor, this, AuthorType.Author));
            }
        }

        public void ChangeGenre
        (
            IGenreStrategy genreStrategy,
            Genre newGenre
        )
        {
            if (genreStrategy.CanChangeGenre(_genre, newGenre))
            {
                _genre = newGenre;
                _genreId = newGenre.Id;
            }
        }

        public void AddCoAuthors
        (
            ICoAuthorStrategy coAuthorStrategy,
            IEnumerable<Author> coAuthors
        )
        {
            foreach (var coAuthor in coAuthors)
            {
                AddCoAuthor(coAuthorStrategy, coAuthor);
            }
        }

        public void AddCoAuthor
        (
            ICoAuthorStrategy coAuthorStrategy,
            Author newCoAuthor
        )
        {
            if (coAuthorStrategy.CanAddCoAuthor(_authors, newCoAuthor))
            {
                _authors.Add(new BookAuthor(newCoAuthor, this, AuthorType.CoAuthor));
            }
        }

        public void RemoveCoAuthor
        (
            ICoAuthorStrategy coAuthorStrategy,
            int id
        )
        {
            if (coAuthorStrategy.CanRemoveCoAuthor(_authors, id))
            {
                var coAuthor = FilterAuthorsBy(x => x.AuthorId == id)
                    .First();

                _authors.Remove(coAuthor);
            }
        }

        public void AddTags(ITagStrategy tagStrategy, IEnumerable<Tag> tags)
        {
            foreach (var tag in tags)
            {
                AddTag(tagStrategy, tag);
            }
        }

        public void AddTag
        (
            ITagStrategy tagStrategy,
            Tag newTag
        )
        {
            if (tagStrategy.CanAddTag(_tags, newTag))
            {
                _tags.Add(newTag);
            }
        }

        public void RemoveTag
        (
            ITagStrategy tagStrategy,
            int id
        )
        {
            if (tagStrategy.CanRemoveTag(_tags, id))
            {
                var tag = FilterTagsBy(x => x.Id == id)
                    .First();

                _tags.Remove(tag);
            }
        }

        private IEnumerable<BookAuthor> FilterAuthorsBy(Func<BookAuthor, bool> predicate)
        {
            return _authors.Where(predicate);
        }

        private IEnumerable<Tag> FilterTagsBy(Func<Tag, bool> predicate)
        {
            return _tags.Where(predicate);
        }
    }
}
