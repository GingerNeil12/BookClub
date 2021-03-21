using System.Collections.Generic;
using BookClub.Catalog.Models;
using BookClub.Catalog.Strategies;
using BookClub.Catalog.Strategies.Implementations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookClub.Catalog.Tests.Strategies
{
    [TestClass]
    public class GivenACoAuthorStrategy
    {
        private ICoAuthorStrategy _strategyUnderTest;

        [TestInitialize]
        public void TestInitialize()
        {
            _strategyUnderTest = new CoAuthorStrategy();
        }

        [TestMethod]
        public void WhenCoAuthorDoesntExistCanAddCoAuthorShouldReturnTrue()
        {
            // Arrange
            var author = new Author()
            {
                Id = 1,
                Name = "NameOne"
            };
            var coAuthor = new Author()
            {
                Id = 2,
                Name = "NameTwo"
            };
            var newCoAuthor = new Author()
            {
                Id = 3,
                Name = "NameThree"
            };

            var book = new Book(author, new Genre());

            var authors = new List<BookAuthor>()
            {
                new BookAuthor(author, book, AuthorType.Author),
                new BookAuthor(coAuthor, book, AuthorType.CoAuthor)
            };

            // Act
            var result = _strategyUnderTest.CanAddCoAuthor(authors, newCoAuthor);

            // Arrange
            result.Should().BeTrue();
        }

        [TestMethod]
        public void WhenCoAuthorDoesExistCanAddCoAuthorShouldReturnFalse()
        {
            // Arrange
            var author = new Author()
            {
                Id = 1,
                Name = "NameOne"
            };
            var coAuthor = new Author()
            {
                Id = 2,
                Name = "NameTwo"
            };
            var newCoAuthor = coAuthor;

            var book = new Book(author, new Genre());

            var authors = new List<BookAuthor>()
            {
                new BookAuthor(author, book, AuthorType.Author),
                new BookAuthor(coAuthor, book, AuthorType.CoAuthor)
            };

            // Act
            var result = _strategyUnderTest.CanAddCoAuthor(authors, newCoAuthor);

            // Arrange
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenCoAuthorExistsCanRemovecoAuthorShouldReturnTrue()
        {
            // Arrange
            var author = new Author()
            {
                Id = 1,
                Name = "NameOne"
            };
            var coAuthor = new Author()
            {
                Id = 2,
                Name = "NameTwo"
            };
            var newCoAuthor = coAuthor;

            var book = new Book(author, new Genre());

            var authors = new List<BookAuthor>()
            {
                new BookAuthor(author, book, AuthorType.Author),
                new BookAuthor(coAuthor, book, AuthorType.CoAuthor)
            };

            // Act
            var result = _strategyUnderTest.CanRemoveCoAuthor(authors, newCoAuthor.Id);

            // Arrange
            result.Should().BeTrue();
        }

        [TestMethod]
        public void WhenAuthorIdUsedCanRemoveCoAuthorReturnsFalse()
        {
            // Arrange
            var author = new Author()
            {
                Id = 1,
                Name = "NameOne"
            };
            var coAuthor = new Author()
            {
                Id = 2,
                Name = "NameTwo"
            };

            var book = new Book(author, new Genre());

            var authors = new List<BookAuthor>()
            {
                new BookAuthor(author, book, AuthorType.Author),
                new BookAuthor(coAuthor, book, AuthorType.CoAuthor)
            };

            // Act
            var result = _strategyUnderTest.CanRemoveCoAuthor(authors, author.Id);

            // Arrange
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenCoAuthorDoesntExistCanRemoveCoAuthorReturnsFalse()
        {
            // Arrange
            var author = new Author()
            {
                Id = 1,
                Name = "NameOne"
            };
            var coAuthor = new Author()
            {
                Id = 2,
                Name = "NameTwo"
            };

            var book = new Book(author, new Genre());

            var authors = new List<BookAuthor>()
            {
                new BookAuthor(author, book, AuthorType.Author),
                new BookAuthor(coAuthor, book, AuthorType.CoAuthor)
            };

            // Act
            var result = _strategyUnderTest.CanRemoveCoAuthor(authors, int.MaxValue);

            // Arrange
            result.Should().BeFalse();
        }
    }
}
