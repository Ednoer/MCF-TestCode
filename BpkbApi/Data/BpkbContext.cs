using System;
using BpkbApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BpkbApi.Data
{
    public class BpkbContext : DbContext
    {
        public BpkbContext(DbContextOptions<BpkbContext> options) : base(options) { }

        public DbSet<TrBpkb> TrBpkbs { get; set; }
        public DbSet<MsStorageLocation> MsStorageLocations { get; set; }
        public DbSet<MsUser> MsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrBpkb>()
                .HasKey(e => e.AgreementNumber);

            modelBuilder.Entity<TrBpkb>()
                .HasOne(p => p.Location)
                .WithMany(b => b.TrBpkbs)
                .HasForeignKey(p => p.LocationId);
        }
    }
}
