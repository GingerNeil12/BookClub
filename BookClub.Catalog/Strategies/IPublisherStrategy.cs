using BookClub.Catalog.Models;

namespace BookClub.Catalog.Strategies
{
    public interface IPublisherStrategy
    {
        bool CanChangePublisher(Publisher currentPublisher, Publisher newPublisher);
    }
}
