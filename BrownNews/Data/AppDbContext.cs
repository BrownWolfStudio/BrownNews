using BrownNews.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BrownNews.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityDbConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Article> SavedArticles { get; set; }
        public DbSet<Source> Sources { get; set; }
    }

    public class EntityDbConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(e => e.Url)
                    .HasConversion(v => v.ToString(), v => new Uri(v));

            builder.Property(e => e.UrlToImage)
                    .HasConversion(v => v.ToString(), v => new Uri(v));
        }
    }

}
