
using System.Text.Json;
using DevExp.CodeChallenge.Configurations;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Compute.v1;
using Google.Apis.Compute.v1.Data;
using Google.Apis.Services;
using static Google.Apis.Requests.BatchRequest;

namespace DevExp.CodeChallenge.Services;

internal class GcpMetadataService : IMetadataService
{
    private readonly GcpSetting _setting;
    public GcpMetadataService(GcpSetting setting)
    {
        _setting = setting;
    }

    async Task<string> IMetadataService.GetMetadataAsync(string instanceId)
    {
        try
        {
            GoogleCredential credential;
            using (var stream = new FileStream("gcp-app-key.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleCredential.FromStreamAsync(stream, default);
            }

            // Initialize Compute Engine API client
            ComputeService computeService = new ComputeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "GCP-Metadata-Tool"
            });

            var request = computeService.Instances.Get(_setting.ProjectId, _setting.Zone, instanceId);
            var instance = await request.ExecuteAsync();

            return JsonSerializer.Serialize(instance);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
