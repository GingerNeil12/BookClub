namespace BookClub.Catalog.Models
{
    public class BookAuthor
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public AuthorType AuthorType { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }

        public BookAuthor()
        {

        }

        public BookAuthor
        (
            Author author,
            Book book,
            AuthorType authorType
        )
        {
            Author = author;
            Book = book;
            AuthorId = author.Id;
            BookId = book.Id;
            AuthorType = authorType;
        }
    }

    public enum AuthorType
    {
        Author,
        CoAuthor
    }
}
