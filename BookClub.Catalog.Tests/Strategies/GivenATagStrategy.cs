using System.Collections.Generic;
using BookClub.Catalog.Models;
using BookClub.Catalog.Strategies;
using BookClub.Catalog.Strategies.Implementations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookClub.Catalog.Tests.Strategies
{
    [TestClass]
    public class GivenATagStrategy
    {
        private ITagStrategy _strategyUnderTest;

        [TestInitialize]
        public void TestInitialize()
        {
            _strategyUnderTest = new TagStrategy();
        }

        [TestMethod]
        public void WhenCurrentTagsDontHaveAnEntryTheSameAsTheNewTagShouldReturnTrue()
        {
            // Arrange
            var currentTags = new List<Tag>()
            {
                new Tag() { Name = "TagOne" },
                new Tag() { Name = "TagTwo" },
                new Tag() { Name = "TagThree" }
            };
            var newTag = new Tag() { Name = "TagFour" };

            // Act
            var result = _strategyUnderTest.CanAddTag(currentTags, newTag);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void WhenCurrentTagsContainAnEntryTheSameAsNewTagShouldReturnFalse()
        {
            // Arrange
            var tagOne = new Tag() { Name = "TagOne" };
            var currentTags = new List<Tag>()
            {
                tagOne,
                new Tag() { Name = "TagTwo" },
                new Tag() { Name = "TagThree" }
            };
            var newTag = tagOne;

            // Act
            var result = _strategyUnderTest.CanAddTag(currentTags, newTag);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenCurrentTagsContainTheProvidedIdShouldReturnTrue()
        {
            // Arrange
            var idToRemove = 1;
            var currentTags = new List<Tag>()
            {
                new Tag() { Id = idToRemove },
                new Tag() { Id = 2 },
                new Tag() { Id = 3 }
            };

            // Act
            var result = _strategyUnderTest.CanRemoveTag(currentTags, idToRemove);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void WhenCurrentTagsDoNotContainTheProvidedIdShouldReturnFalse()
        {
            // Arrange
            var currentTags = new List<Tag>()
            {
                new Tag() { Id = 1 },
                new Tag() { Id = 2 },
                new Tag() { Id = 3 }
            };

            // Act
            var result = _strategyUnderTest.CanRemoveTag(currentTags, int.MaxValue);

            // Assert
            result.Should().BeFalse();
        }
    }
}
