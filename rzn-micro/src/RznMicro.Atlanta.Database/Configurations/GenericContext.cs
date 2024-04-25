using Microsoft.EntityFrameworkCore;

namespace RznMicro.Atlanta.Database.Configurations;

public class GenericContext : DbContext
{
    public GenericContext(DbContextOptions options) : base(options)
    {
        Database.SetCommandTimeout(36000);
        ChangeTracker.AutoDetectChangesEnabled = false;
    }
}
