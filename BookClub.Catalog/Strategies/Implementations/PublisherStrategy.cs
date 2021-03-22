using BookClub.Catalog.Models;

namespace BookClub.Catalog.Strategies.Implementations
{
    public class PublisherStrategy : IPublisherStrategy
    {
        public bool CanChangePublisher
        (
            Publisher currentPublisher,
            Publisher newPublisher
        )
        {
            return currentPublisher.NormalizedName != newPublisher.NormalizedName;
        }
    }
}
