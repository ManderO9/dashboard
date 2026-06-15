namespace Dashboard;

public class AppSettings
{
    public const string SettingsLocalStorageKey = "__App_Settings";
    public string SupabaseUrl { get; set; } = string.Empty;
    public string SupabaseKey { get; set; } = string.Empty;
}
