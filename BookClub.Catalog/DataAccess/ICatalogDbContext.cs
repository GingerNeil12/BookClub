using System.Threading;
using System.Threading.Tasks;
using BookClub.Catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClub.Catalog.DataAccess
{
    interface ICatalogDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<BookAuthor> BookAuthors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Tag> Tags { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}