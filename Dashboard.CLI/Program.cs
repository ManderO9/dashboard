using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
services.AddDbContext<AppDbContext>(options => options.UseNpgsql(config.GetConnectionString("Default")));

var sp = services.BuildServiceProvider();


using var scope = sp.CreateScope();

using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
Console.WriteLine("Running migrations...");
await db.Database.MigrateAsync();
Console.WriteLine("Finished Running migrations");

Console.WriteLine("Press Enter to exist");
Console.ReadLine();
