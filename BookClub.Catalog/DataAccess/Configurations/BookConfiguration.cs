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
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.NonFiction)
                .IsRequired();

            builder.Property(x => x.HardBack)
                .IsRequired();

            builder.Property(x => x.GenreId)
                .HasField("_genreId")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(x => x.PageCount)
                .IsRequired(false);

            builder.Property(x => x.Edition)
                .IsRequired(false);

            builder.Property(x => x.PublishedOn)
                .IsRequired(false);

            builder.Navigation(x => x.Authors)
                .HasField("_authors")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Navigation(x => x.Tags)
                .HasField("_tags")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasMany(x => x.Authors)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Books);
        }
    }
}
