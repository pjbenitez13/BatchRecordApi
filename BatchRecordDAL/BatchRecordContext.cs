﻿using BatchRecordDAL.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Runtime.InteropServices.JavaScript;
using System.Xml.Linq;
namespace BatchRecordDAL
{

    public class BatchRecordContext : DbContext
    {
        private readonly string _connection;
        private static readonly string Migrations = "_ef_migrations";
        private static readonly string Schema = "test";

        public BatchRecordContext(
            string? dbName = null,
            string? dbHost = null,
            string? dbUser = null,
            string? dbPassword = null,
            string? dbPort = null) : base()
        {

            if (string.IsNullOrEmpty(dbName)) dbName = "BatchRecord";
            if (string.IsNullOrEmpty(dbHost)) dbHost = "localhost";
            if (string.IsNullOrEmpty(dbUser)) dbUser = "postgres";
            if (string.IsNullOrEmpty(dbPassword)) dbPassword = "1234";
            if (string.IsNullOrEmpty(dbPort)) dbPort = "5432";

            _connection = $"Host={dbHost};PORT={dbPort};Database={dbName};Username={dbUser};Password={dbPassword};Pooling=False";
            Console.WriteLine(_connection);
        }
    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Database=test;Username=postgres;Password=1234");
            optionsBuilder.UseNpgsql(_connection, x => x.MigrationsHistoryTable(Migrations, Schema));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(Schema);

            // User
            modelBuilder.Entity<User>().HasKey(u => u.IdUser);

            modelBuilder.Entity<User>()
                        .Property(u => u.UserType)
                        .HasConversion(us => us.ToString(), us => Enum.Parse<UserType>(us));

            modelBuilder.Entity<User>()
                        .HasIndex(u => u.Email)
                        .IsUnique();

            modelBuilder.Entity<User>()
                        .HasOne(ba => ba.Role)
                        .WithMany(b => b.Users)
                        .HasForeignKey(ba => ba.RoleId);

            // Role
            modelBuilder.Entity<Role>()
                        .HasKey(u => u.RoleId);

            // AccessResources

            modelBuilder.Entity<AccessResource>().HasKey(u => u.ResourceId);

            modelBuilder.Entity<AccessResource>()
                        .HasIndex(u => u.ResourceName)
                        .IsUnique();

            modelBuilder.Entity<AccessResource>()
                        .HasOne(ba => ba.Role)
                        .WithMany(b => b.AccessResources)
                        .HasForeignKey(ba => ba.RoleId);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccessResource> AccessResources { get; set; }

    }

}
