using Dashboard.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Tests;

public class DashboardTests
{
    [Fact]
    public async Task Assert_NoPendingMigrations()
    {
        var services = new ServiceCollection();
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(""));
        var sp = services.BuildServiceProvider();
        
        using var scope = sp.CreateScope();
        using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        Assert.False(db.Database.HasPendingModelChanges());
    }

    [Fact]
    public async Task Assert_AllModelsAreInDbContext()
    {
        // Get all entities that inherit from BaseModel in the dashboard assembly
        var entities = typeof(Home).Assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Supabase.Postgrest.Models.BaseModel)))
            .ToList();

        // Get all properties of type DbSet from AppDbContext
        var properties = typeof(AppDbContext).GetProperties()
            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            .ToList();

        // Make sure they are equal
        Assert.Equal(entities.Count, properties.Count + 1);
    }
}
