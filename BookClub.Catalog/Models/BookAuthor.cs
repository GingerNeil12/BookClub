namespace BookClub.Catalog.Models
{
    public class BookAuthor
    {
        private int _authorId;
        private int _bookId;

        private Author _author;
        private Book _book;

        public int AuthorId { get { return _authorId; } }
        public int BookId { get { return _bookId; } }

        public virtual Author Author { get { return _author; } }
        public virtual Book Book { get { return _book; } }

        public BookAuthor()
        {

        }

        public BookAuthor
        (
            Author author,
            Book book
        )
        {
            _author = author;
            _book = book;
            _authorId = author.Id;
            _bookId = book.Id;
        }
    }
}
