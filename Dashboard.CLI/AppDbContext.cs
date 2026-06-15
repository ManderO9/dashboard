using Dashboard;
using Microsoft.EntityFrameworkCore;
using Supabase.Postgrest.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<City> City { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Model.GetEntityTypes().ToList().ForEach(entityType =>
        {
            if(typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType).Ignore(nameof(BaseModel.RequestClientOptions));
                modelBuilder.Entity(entityType.ClrType).Ignore(nameof(BaseModel.BaseUrl));
                modelBuilder.Entity(entityType.ClrType).Ignore(nameof(BaseModel.TableName));
                modelBuilder.Entity(entityType.ClrType).Ignore(nameof(BaseModel.PrimaryKey));
            }
        });

    }
}
