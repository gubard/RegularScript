﻿using System;
using Microsoft.EntityFrameworkCore;
using RegularScript.Db.Helpers;

namespace RegularScript.Db.Contexts;

public class RegularScriptDbContext : DbContext
{
    protected RegularScriptDbContext()
    {
    }

    public RegularScriptDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var assembly in assemblies)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        SeedHelper.SeedLanguages(modelBuilder);
    }
}