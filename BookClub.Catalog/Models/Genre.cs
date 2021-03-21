using System.Collections.Generic;

namespace BookClub.Catalog.Models
{
    public class Genre
    {
        private ICollection<Book> _books;

        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName => Name.ToUpperInvariant();

        public virtual IEnumerable<Book> Books => _books;

        public Genre()
        {
            _books = new List<Book>();
        }
    }
}
