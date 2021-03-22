using BookClub.Catalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookClub.Catalog.DataAccess.Configurations
{
    class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author", DbSchema.Catalog)
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

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
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
                .HasField("_bookAuthors");

            builder.HasMany(x => x.BookAuthors)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
