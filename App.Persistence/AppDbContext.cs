using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.Entity<Collaborator>().OwnsOne(x => x.Email).Property(x => x.Address).HasColumnName("Email").IsRequired(true);
            modelBuilder.Entity<Collaborator>().OwnsOne(x => x.Name, name =>
            {
                name.Property(x => x.FirstName).HasColumnName("Name");
                name.Property(x => x.LastName).HasColumnName("Name");
            });
            modelBuilder.Entity<Collaborator>().OwnsOne(x => x.KeyPassword).Property(x => x.Key).HasColumnName("Key").IsRequired(true);

            modelBuilder.Entity<Company>().OwnsOne(x => x.Name, name =>
            {
                name.Property(x => x.FirstName).HasColumnName("Name");
                name.Property(x => x.LastName).HasColumnName("Name");
            });
        }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}
