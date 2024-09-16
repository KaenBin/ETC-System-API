using ETC_System_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETC_System_API.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<ReaderDevice> ReaderDevice { get; set; }
        public DbSet<TollStation> TollStation { get; set; }
        public DbSet<TollTag> TollTag { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleOwner> VehicleOwner { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<ManageTag> ManageTag { get; set; }
        public DbSet<ReadTag> ReadTag { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<Vehicle>(x => x.HasIndex(p => p.TollTagId).IsUnique());

            builder.Entity<TollTag>().HasMany(x => x.Payment).WithOne(x => x.TollTag).HasForeignKey(x => x.TollTagId);
            builder.Entity<TollTag>().HasMany(x => x.ManageTag).WithOne(x => x.TollTag).HasForeignKey(x => x.TollTagId);
            builder.Entity<TollTag>().HasMany(x => x.ReadTag).WithOne(x => x.TollTag).HasForeignKey(x => x.TollTagId);

            builder.Entity<TollStation>(x => x.HasKey(p => p.Id));
            builder.Entity<TollStation>().HasMany(x => x.Devices).WithOne(x => x.TollStation).HasForeignKey(x => x.TollStationId);

            builder.Entity<Vehicle>()
                    .HasOne(e => e.TollTag)
                    .WithOne(e => e.Vehicle)
                    .HasForeignKey<TollTag>(e => e.VehicleId);

            // builder.Entity<TollTag>()
            //         .HasOne(e => e.Vehicle)
            //         .WithOne(e => e.TollTag)
            //         .HasForeignKey<TollTag>(e => e.VehicleId);

            builder.Entity<Payment>().HasOne(x => x.TollTag).WithMany(x => x.Payment).HasForeignKey(x => x.TollTagId);
            builder.Entity<Payment>().HasOne(x => x.ReaderDevice).WithMany(x => x.Payment).HasForeignKey(x => x.ReaderDeviceId);

            builder.Entity<ManageTag>(x => x.HasKey(p => new { p.AdminId, p.TollTagId }));
            builder.Entity<ManageTag>().HasOne(x => x.Admin).WithMany(x => x.ManageTag).HasForeignKey(x => x.AdminId);
            builder.Entity<ManageTag>().HasOne(x => x.TollTag).WithMany(x => x.ManageTag).HasForeignKey(x => x.TollTagId);

            builder.Entity<ReadTag>(x => x.HasKey(p => new { p.ReaderDeviceId, p.TollTagId }));
            builder.Entity<ReadTag>().HasOne(x => x.ReaderDevice).WithMany(x => x.ReadTag).HasForeignKey(x => x.ReaderDeviceId);
            builder.Entity<ReadTag>().HasOne(x => x.TollTag).WithMany(x => x.ReadTag).HasForeignKey(x => x.TollTagId);

            List<IdentityRole> roles =
            [
                new() {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new() {
                    Name = "Owner",
                    NormalizedName = "OWNER"
                }
            ];

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

