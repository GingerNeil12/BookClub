using BookClub.Catalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookClub.Catalog.DataAccess.Configurations
{
    class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable("BookAuthor", DbSchema.Catalog)
                .HasKey(x => new { x.AuthorId, x.BookId });

            builder.Property(x => x.AuthorId)
                .HasField("_authorId")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
                .IsRequired();

            builder.Property(x => x.BookId)
                .HasField("_bookId")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
                .IsRequired();

            builder.HasOne(x => x.Author)
                .WithMany(x => x.BookAuthors)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookAuthors)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
