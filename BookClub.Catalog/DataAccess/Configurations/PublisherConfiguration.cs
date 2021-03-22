using BookClub.Catalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookClub.Catalog.DataAccess.Configurations
{
    class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("Publisher", DbSchema.Catalog)
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.HasIndex(x => x.Name)
                .IsUnique();

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

            builder.Navigation(x => x.Books)
                .HasField("_books")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasMany(x => x.Books)
                .WithOne(x => x.Publisher)
                .HasForeignKey(x => x.PublisherId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
