using Microsoft.EntityFrameworkCore;
using NibulonTestTask.Core.Models;
using NibulonTestTask.Persistence.Configurations;

namespace NibulonTestTask.Persistence.Data
{
    public class NibulonTestTaskDbContext : DbContext
    {
        public DbSet<AUP> AUPs => Set<AUP>();
        public DbSet<OBL> OBLs => Set<OBL>();
        public DbSet<KRAJ> KRAJs => Set<KRAJ>();
        public DbSet<City> Cities => Set<City>();

        public NibulonTestTaskDbContext(DbContextOptions<NibulonTestTaskDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AUPConfiguration());
            modelBuilder.ApplyConfiguration(new OBLConfiguration());
            modelBuilder.ApplyConfiguration(new KRAJConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
        }
    }
}
