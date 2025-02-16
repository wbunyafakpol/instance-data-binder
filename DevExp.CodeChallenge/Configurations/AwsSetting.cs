using Microsoft.Extensions.Configuration;

namespace DevExp.CodeChallenge.Configurations;

internal class AwsSetting
{
    public readonly string? AccessKey;
    public readonly string? SecretKey;
    public readonly string? Region;

    public AwsSetting(IConfigurationRoot configurationRoot)
    {
        AccessKey = configurationRoot.GetValue<string>("Aws:ACCESS_KEY")?.ToString();
        SecretKey = configurationRoot.GetValue<string>("Aws:SECRET_KEY")?.ToString();
        Region = configurationRoot.GetValue<string>("Aws:Region")?.ToString();
    }
}
