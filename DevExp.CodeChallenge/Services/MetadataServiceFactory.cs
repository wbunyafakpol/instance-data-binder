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
                return new AzureMetadataService();
            case "gcp":
                return new GcpMetadataService();
            default:
                throw new ArgumentException("Invalid cloud provider specified");
        }
    }
}
