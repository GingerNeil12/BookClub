using System.Collections.Generic;
using BookClub.Catalog.Models;

namespace BookClub.Catalog.Strategies
{
    public interface ITagStrategy
    {
        bool CanAddTag(IEnumerable<Tag> tags, Tag newTag);
        bool CanRemoveTag(IEnumerable<Tag> tags, int id);
    }
}
