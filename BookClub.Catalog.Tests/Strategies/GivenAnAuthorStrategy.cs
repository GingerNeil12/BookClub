using System.Collections.Generic;
using BookClub.Catalog.Models;
using BookClub.Catalog.Strategies;
using BookClub.Catalog.Strategies.Implementations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookClub.Catalog.Tests.Strategies
{
    [TestClass]
    public class GivenAnAuthorStrategy
    {
        private IAuthorStrategy _strategyUnderTest;

        [TestInitialize]
        public void TestInitialize()
        {
            _strategyUnderTest = new AuthorStrategy();
        }

        [TestMethod]
        public void WhenNewAuthorIsTheSameAsCurrentAuthorShouldReturnFalse()
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
            var newAuthor = author;

            var book = new Book(author, new Genre());

            var authors = new List<BookAuthor>()
            {
                new BookAuthor(author, book, AuthorType.Author),
                new BookAuthor(coAuthor, book, AuthorType.CoAuthor)
            };

            // Act
            var result = _strategyUnderTest.CanChangeAuthor(authors, newAuthor);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenNewAuthorIsACoAuthorShouldReturnFalse()
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
            var newAuthor = coAuthor;

            var book = new Book(author, new Genre());

            var authors = new List<BookAuthor>()
            {
                new BookAuthor(author, book, AuthorType.Author),
                new BookAuthor(coAuthor, book, AuthorType.CoAuthor)
            };

            // Act
            var result = _strategyUnderTest.CanChangeAuthor(authors, newAuthor);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenNewAuthorIsntTheCurrentAuthorOrACoAuthorShouldReturnTrue()
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
            var newAuthor = new Author()
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
            var result = _strategyUnderTest.CanChangeAuthor(authors, newAuthor);

            // Assert
            result.Should().BeTrue();
        }
    }
}
