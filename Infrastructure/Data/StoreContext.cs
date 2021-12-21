using System.Linq;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        //unityofwork
        public StoreContext(DbContextOptions<StoreContext> options) : base()
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=acara.db");
        }

        protected override void OnModelCreating(ModelBuilder _modelBuilder)
        {
            base.OnModelCreating(_modelBuilder);
            _modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entitytype in _modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entitytype.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        _modelBuilder.Entity(entitytype.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }

        }

    }
}