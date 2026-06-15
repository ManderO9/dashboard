using Microsoft.JSInterop;

namespace Dashboard;

public static class LocalStorageExtensions
{
    public static void SaveAppSettings(this ILocalStorageService localStorage, AppSettings settings)
    {
        localStorage.SetItem(AppSettings.SettingsLocalStorageKey, settings);
    }

    public static AppSettings GetAppSettings(this ILocalStorageService localStorage)
    {
        return localStorage.GetItem<AppSettings>(AppSettings.SettingsLocalStorageKey) ?? new();
    }
}