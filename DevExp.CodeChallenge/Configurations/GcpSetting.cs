using Microsoft.Extensions.Configuration;

namespace DevExp.CodeChallenge.Configurations;

internal class GcpSetting
{
    public readonly string? ProjectId;
    public readonly string? Zone;

    public GcpSetting(IConfigurationRoot configurationRoot, string zone)
    {
        ProjectId = configurationRoot.GetValue<string>("Gcp:ProjectId")?.ToString();
        Zone = zone;
    }
}
