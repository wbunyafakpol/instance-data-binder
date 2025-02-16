using DevExp.CodeChallenge.Services;

internal class Program
{
    private static string? _cloudProvider;
    private static string? _instanceId;
    static async Task Main(string[] args)
    {
        while (_cloudProvider != "exit") 
        {
            try
            {
                InputBinding();
    
            if (string.IsNullOrWhiteSpace(_cloudProvider) || string.IsNullOrWhiteSpace(_instanceId))
                {
                    Console.WriteLine("Please enter correct cloud provider and instance id");
                    return;
                }

                var metadataService = MetadataServiceFactory.CreateMetadataService(_cloudProvider);
                string metadata = await metadataService.GetMetadataAsync(_instanceId);
                Console.WriteLine($"Metadata for {_cloudProvider}, instance id: {_instanceId}");
                Console.WriteLine(metadata);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static void InputBinding()
    {

        Console.WriteLine("Enter cloud provider (aws/azure/gcp) or exit:");
        _cloudProvider = Console.ReadLine();
        Console.WriteLine("Enter instance id:");
        _instanceId = Console.ReadLine();
    }
}