using DevExp.CodeChallenge.Configurations;
using Microsoft.Extensions.Configuration;

namespace DevExp.CodeChallenge.Services;

internal static class MetadataServiceFactory
{
    public static IMetadataService CreateMetadataService(string cloudProvider)
    {
        var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set base directory
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        switch (cloudProvider.ToLower())
        {
            case "aws":
                return new AwsMetadataService(new AwsSetting(config));
            case "azure":
                return new AzureMetadataService(new AzureSetting(config));
            case "gcp":
                return new GcpMetadataService(new GcpSetting(config));
            default:
                throw new ArgumentException("Invalid cloud provider specified");
        }
    }
}
