﻿using System;
using System.Collections.Generic;
using System.Linq;
using BookClub.Catalog.Strategies;

namespace BookClub.Catalog.Models
{
    public class Book : AuditableEntity
    {
        private Genre _genre;
        private Publisher _publisher;
        private ICollection<BookAuthor> _bookAuthors;
        private ICollection<Tag> _tags;

        private int _genreId;
        private int _publisherId;

        public int Id { get; set; }
        public string Title { get; set; }
        public string NormalizedTitle => Title.ToUpperInvariant();
        public string Synopsis { get; set; }
        public string ISBN { get; set; }
        public bool NonFiction { get; set; }
        public bool HardBack { get; set; }
        public int GenreId { get { return _genreId; } }
        public int PublisherId { get { return _publisherId; } }
        public int? Edition { get; set; }
        public int? PageCount { get; set; }
        public DateTime? PublishedOn { get; set; }

        public virtual Genre Genre { get { return _genre; } }
        public virtual Publisher Publisher { get { return _publisher; } }
        public virtual IEnumerable<BookAuthor> BookAuthors { get { return _bookAuthors; } }
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
        /// <param name="publisher">The publisher.</param>
        public Book
        (
            Author author,
            Genre genre,
            Publisher publisher
        )
        {
            _bookAuthors = new List<BookAuthor>()
            {
                new BookAuthor(author, this)
            };
            _tags = new List<Tag>();

            _genre = genre;
            _genreId = genre.Id;

            _publisher = publisher;
            _publisherId = publisher.Id;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _bookAuthors.Select(x => x.Author);
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
            return _bookAuthors.Where(predicate);
        }

        private IEnumerable<Tag> FilterTagsBy(Func<Tag, bool> predicate)
        {
            return _tags.Where(predicate);
        }
    }
}
