//#define DELETE_DB
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SpaRNP.Models;
using System;
using SpaRNP.Context.EntityConfiguration;

namespace SpaRNP.Context
{
    public class AnalysisContext : DbContext
    {
        public AnalysisContext(DbContextOptions<AnalysisContext> options) : base(options)
        {
#if DELETE_DB
            Database.EnsureDeleted();
#endif
            Database.EnsureCreated();
        }

        public DbSet<AnalysisUser> AnalysisUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AnalysisUsersEntityTypeConfiguration());

            builder.Entity<AnalysisUser>().HasData(
                new AnalysisUser[]
                {
                    new () {Id = 1, RegisteredAt = new DateTime(2021, 3, 3), ActiveAt = new DateTime(2021, 3,15) },
                    new () {Id = 2, RegisteredAt = new DateTime(2021, 3, 15), ActiveAt = new DateTime(2021, 3,15) },
                    new () {Id = 3, RegisteredAt = new DateTime(2021, 3, 10), ActiveAt = new DateTime(2021, 3,10) },
                    new () {Id = 4, RegisteredAt = new DateTime(2021, 3, 11), ActiveAt = new DateTime(2021, 3,11) },
                    new () {Id = 5, RegisteredAt = new DateTime(2021, 3, 12), ActiveAt = new DateTime(2021, 3,12) },
                });
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }

    public class AnalysisContextDesignFactory : IDesignTimeDbContextFactory<AnalysisContext>
    {
        public AnalysisContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AnalysisContext>()
                .UseNpgsql("Server=127.0.0.1;Port=5432;Database=AnalysisUsers;User Id=analysis;Password=analysis;");

            return new AnalysisContext(optionsBuilder.Options);
        }
    }
}
