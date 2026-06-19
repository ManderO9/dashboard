using Dashboard;
using Microsoft.EntityFrameworkCore;
using Supabase.Postgrest.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    // Make sure that the name of the property is not in plural, but it is exactly the same as the name of the model class
    public DbSet<Idea> Idea { get; set; }
    public DbSet<Prompt> Prompt { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Prompt>().HasIndex(x => x.KeyName).IsUnique(true);

        builder.Model.GetEntityTypes().ToList().ForEach(entityType =>
        {
            if(typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
            {
                builder.Entity(entityType.ClrType).Ignore(nameof(BaseModel.RequestClientOptions));
                builder.Entity(entityType.ClrType).Ignore(nameof(BaseModel.BaseUrl));
                builder.Entity(entityType.ClrType).Ignore(nameof(BaseModel.TableName));
                builder.Entity(entityType.ClrType).Ignore(nameof(BaseModel.PrimaryKey));
            }
        });

    }
}
