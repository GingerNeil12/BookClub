using BookClub.Catalog.Models;
using BookClub.Catalog.Strategies;
using BookClub.Catalog.Strategies.Implementations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookClub.Catalog.Tests.Strategies
{
    [TestClass]
    public class GivenAGenreStrategy
    {
        private IGenreStrategy _strategyUnderTest;

        [TestInitialize]
        public void TestInitialize()
        {
            _strategyUnderTest = new GenreStrategy();
        }

        [TestMethod]
        public void WhenTheCurrentGenreNameAndNewGenreNameMatchShouldReturnFalse()
        {
            // Arrange
            var name = "GenreOne";
            var currentGenre = new Genre()
            {
                Id = 1,
                Name = name
            };
            var newGenre = new Genre()
            {
                Id = 2,
                Name = name
            };

            // Act
            var result = _strategyUnderTest.CanChangeGenre(currentGenre, newGenre);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenTheNewGenreIsNotTheSameAsTheCurrentOneShouldReturnTrue()
        {
            // Arrange
            var currentGenre = new Genre()
            {
                Id = 1,
                Name = "GenreOne"
            };
            var newGenre = new Genre()
            {
                Id = 2,
                Name = "GenreTwo"
            };

            // Act
            var result = _strategyUnderTest.CanChangeGenre(currentGenre, newGenre);

            // Assert
            result.Should().BeTrue();
        }
    }
}
