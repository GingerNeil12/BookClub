using BookClub.Catalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookClub.Catalog.DataAccess.Configurations
{
    class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre", DbSchema.Catalog)
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Navigation(x => x.Books)
                .HasField("_books")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasMany(x => x.Books)
                .WithOne(x => x.Genre)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
