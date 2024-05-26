namespace Global.Fretes.Infrastructure.Azure;

public static class ConfigKeyAzureContainer
{
    public static string Key { get; private set; } = string.Empty;
    public static string Container { get; private set; } = string.Empty;

    public static void Configure(string key, string container)
    {
        Key = key;
        Container = container;
    }
}
