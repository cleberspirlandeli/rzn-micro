using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RznMicro.Atlanta.Feature.Address.Model;

namespace RznMicro.Atlanta.Database.MappingModels.Feature;

public class AddressMap : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.ToTable("Address");

        builder
            .HasKey(x => x.Id);

        builder
            .HasKey(x => x.IdUser);

        builder
            .Property(x => x.ZipCode)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder
            .Property(x => x.Street)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder
            .Property(x => x.Number)
            .IsRequired();

        builder
            .Property(x => x.AdditionalInformation)
            .IsRequired(false)
            .HasColumnType("varchar(250)");

        builder
            .Property(x => x.TypeOfAddress)
            .IsRequired(false)
            .HasConversion<int>();
    }
}
