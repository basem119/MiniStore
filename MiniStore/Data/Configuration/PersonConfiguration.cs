using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MiniStore.Models.Entities;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

        builder.HasDiscriminator<string>("PersonType");
      
        builder.ToTable("People");

    }
}