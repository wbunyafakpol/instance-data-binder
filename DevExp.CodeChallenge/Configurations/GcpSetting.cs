using Microsoft.Extensions.Configuration;

namespace DevExp.CodeChallenge.Configurations;

internal class GcpSetting
{
    public readonly string? ProjectId;
    public readonly string? Zone;

    public GcpSetting(IConfigurationRoot configurationRoot)
    {
        ProjectId = configurationRoot.GetValue<string>("Gcp:ProjectId")?.ToString();
        Zone = configurationRoot.GetValue<string>("Gcp:Zone")?.ToString();
    }
}
