using BookClub.Catalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookClub.Catalog.DataAccess.Configurations
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book", DbSchema.Catalog)
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Synopsis)
                .IsRequired(false);

            builder.Property(x => x.ISBN)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.NonFiction)
                .IsRequired();

            builder.Property(x => x.HardBack)
                .IsRequired();

            builder.Property(x => x.GenreId)
                .HasField("_genreId")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(x => x.PublisherId)
                .HasField("_publisherId")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(x => x.PageCount)
                .IsRequired(false);

            builder.Property(x => x.Edition)
                .IsRequired(false);

            builder.Property(x => x.PublishedOn)
                .IsRequired(false);

            builder.Property(x => x.CreatedBy)
                .IsRequired();

            builder.Property(x => x.CreatedOn)
                .IsRequired();

            builder.Property(x => x.UpdatedBy)
                .IsRequired(false);

            builder.Property(x => x.UpdatedOn)
                .IsRequired(false);

            builder.Property(x => x.RowVersion)
                .IsRowVersion();

            builder.Navigation(x => x.BookAuthors)
                .HasField("_bookAuthors")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Navigation(x => x.Tags)
                .HasField("_tags")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasOne(x => x.Genre)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Publisher)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.PublisherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.BookAuthors)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Books);
        }
    }
}
