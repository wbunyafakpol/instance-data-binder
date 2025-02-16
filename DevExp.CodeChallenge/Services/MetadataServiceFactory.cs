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
                Console.WriteLine("Enter resource group:");
                var resourceGroup = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    throw new ArgumentException("Please enter correct resource group");
                }

                return new AzureMetadataService(new AzureSetting(config, resourceGroup));
            case "gcp":
                Console.WriteLine("Enter zone(default us-central1-a):");
                var zone = Console.ReadLine() ?? "us-central1-a";
                return new GcpMetadataService(new GcpSetting(config, zone));
            default:
                throw new ArgumentException("Invalid cloud provider specified");
        }
    }
}
