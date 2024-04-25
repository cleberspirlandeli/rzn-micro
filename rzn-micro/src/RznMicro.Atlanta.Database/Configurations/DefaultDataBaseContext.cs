﻿using Microsoft.EntityFrameworkCore;
using RznMicro.Atlanta.Database.Configurations;

namespace RznMicro.Atlanta.Database.Feature;

public partial class DefaultDataBaseContext : GenericContext
{
    public DefaultDataBaseContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
