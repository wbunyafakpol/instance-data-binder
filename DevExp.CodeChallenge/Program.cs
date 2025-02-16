using DevExp.CodeChallenge.Services;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Enter cloud provider (aws/azure/gcp):");
        string? cloudProvider = Console.ReadLine();
        Console.WriteLine("Enter instance id:");
        string? instanceId = Console.ReadLine();

        try
        {
            if (string.IsNullOrWhiteSpace(cloudProvider) || string.IsNullOrWhiteSpace(instanceId))
            {
                Console.WriteLine("Please enter correct cloud provider and instance id");
                return;
            }

            var metadataService = MetadataServiceFactory.CreateMetadataService(cloudProvider);
            string metadata = await metadataService.GetMetadataAsync(instanceId);
            Console.WriteLine($"Metadata for {cloudProvider}, instance id: {instanceId}");
            Console.WriteLine(metadata);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}