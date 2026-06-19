using Dashboard;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Google.GenAI;
using Microsoft.Extensions.AI;
using Microsoft.JSInterop;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddLocalStorageServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<DataStore>();

builder.Services.AddChatClient(sp => {
    var localStorage = sp.GetRequiredService<ILocalStorageService>();
    var settings = localStorage.GetAppSettings();

    return new Client(apiKey: settings.AiApiKey).AsIChatClient(settings.AiModelName);
});

var app = builder.Build();

await app.RunAsync();
