using Microsoft.Extensions.Configuration;

namespace DevExp.CodeChallenge.Configurations;

internal class AzureSetting
{
    public readonly string? ClientId;
    public readonly string? ClientSecret;
    public readonly string? TenantId;
    public readonly string? SubscriptionId;

    public AzureSetting(IConfigurationRoot configurationRoot)
    {
        ClientId = configurationRoot.GetValue<string>("Azure:ClientId")?.ToString();
        ClientSecret = configurationRoot.GetValue<string>("Azure:ClientSecret")?.ToString();
        TenantId = configurationRoot.GetValue<string>("Azure:TenantId")?.ToString();
        SubscriptionId = configurationRoot.GetValue<string>("Azure:SubscriptionId")?.ToString();
    }
}
