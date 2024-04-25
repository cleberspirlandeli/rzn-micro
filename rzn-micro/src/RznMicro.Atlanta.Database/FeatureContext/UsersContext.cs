using Microsoft.EntityFrameworkCore;
using RznMicro.Atlanta.Database.Configurations;
using RznMicro.Atlanta.Feature.Address.Model;
using RznMicro.Atlanta.Feature.User.Model;

namespace RznMicro.Atlanta.Database.Feature;

public partial class DefaultDataBaseContext : GenericContext
{
    public virtual DbSet<UserEntity> User { get; set; }
    public virtual DbSet<AddressEntity> Address { get; set; }
}
