using BookClub.Catalog.Models;

namespace BookClub.Catalog.Strategies.Implementations
{
    public class GenreStrategy : IGenreStrategy
    {
        public bool CanChangeGenre(Genre currentGenre, Genre newGenre)
        {
            return currentGenre.NormalizedName != newGenre.NormalizedName;
        }
    }
}
