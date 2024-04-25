using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RznMicro.Atlanta.Feature.User.Model;

namespace RznMicro.Atlanta.Database.MappingModels.Feature;

public class UserMap : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("User");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.FullName)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder
            .Property(x => x.DateBirth)
            .IsRequired();

        builder
            .Property(x => x.Active)
            .IsRequired(false);

        builder
            .Property(x => x.Gender)
            .IsRequired()
            .HasConversion<int>();

        // 1 : N => User : Address
        builder
            .HasMany(x => x.Address)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.IdUser);
    }
}
