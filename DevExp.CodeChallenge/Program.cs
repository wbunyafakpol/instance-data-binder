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
            
       
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}