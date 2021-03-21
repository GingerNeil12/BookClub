using BookClub.Catalog.Models;

namespace BookClub.Catalog.Strategies
{
    public interface IGenreStrategy
    {
        bool CanChangeGenre(Genre currentGenre, Genre newGenre);
    }
}
