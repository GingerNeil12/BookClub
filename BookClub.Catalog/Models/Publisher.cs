using System.Collections.Generic;

namespace BookClub.Catalog.Models
{
    public class Publisher
    {
        private ICollection<Book> _books;

        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName => Name.ToUpperInvariant();

        public virtual IEnumerable<Book> Books { get { return _books; } }

        public Publisher()
        {
            _books = new List<Book>();
        }
    }
}
