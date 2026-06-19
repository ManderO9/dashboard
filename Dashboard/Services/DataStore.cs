
using Microsoft.JSInterop;
using Supabase;

namespace Dashboard;

public class DataStore
{
    private readonly ILocalStorageService mLocalStorageService;

    public DataStore(ILocalStorageService mLocalStorageService) => this.mLocalStorageService = mLocalStorageService;

    public async Task<Client> GetClientAsync()
    {
        var appSettings = mLocalStorageService.GetAppSettings();
        var options = new SupabaseOptions
        {
            AutoConnectRealtime = false
        };

        var client = new Client(appSettings.SupabaseUrl, appSettings.SupabaseKey, options);

        await client.InitializeAsync();

        return client;
    }
}
