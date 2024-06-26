﻿using Confitec.Technical.Test.Domain.ParametersModule;
using Confitec.Technical.Test.Domain.RecoveryPasswordModule;
using Confitec.Technical.Test.Domain.SystemUserModule;
using Confitec.Technical.Test.Domain.SystemUserModule.Permissions;
using Confitec.Technical.Test.Domain.UserModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Confitec.Technical.Test.Infra.Data
{
    public class TechnicalTestContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TechnicalTestContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("TechnicalTest"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            // Default data
            modelBuilder.Entity<SystemUser>().HasData(SystemUser.DefaultUser());
            modelBuilder.Entity<Parameter>().HasData(Parameter.GetDefaultParameters());
            modelBuilder.Entity<Permission>().HasData(Permission.AllPermissions());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<RecoveryPassword> RecoveryPassword { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}
