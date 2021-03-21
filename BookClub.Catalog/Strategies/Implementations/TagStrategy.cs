using System;
using System.Collections.Generic;
using System.Linq;
using BookClub.Catalog.Models;

namespace BookClub.Catalog.Strategies.Implementations
{
    public class TagStrategy : ITagStrategy
    {
        public bool CanAddTag(IEnumerable<Tag> tags, Tag newTag)
        {
            return !FilterTagsBy
            (
                tags,
                x => x.NormalizedName == newTag.NormalizedName
            ).Any();
        }

        public bool CanRemoveTag(IEnumerable<Tag> tags, int id)
        {
            return FilterTagsBy(tags, x => x.Id == id).Any();
        }

        private static IEnumerable<Tag> FilterTagsBy
        (
            IEnumerable<Tag> tags,
            Func<Tag, bool> predicate
        )
        {
            return tags.Where(predicate);
        }
    }
}
