
using System.Text;
using System.Text.Json;
using DevExp.CodeChallenge.Configurations;

namespace DevExp.CodeChallenge.Services;

internal class AzureMetadataService : IMetadataService
{
    private readonly AzureSetting _setting;
    public AzureMetadataService(AzureSetting setting)
    {
        _setting = setting;
    }

    async Task<string> IMetadataService.GetMetadataAsync(string instanceId)
    {
        try
        {
            var accessToken = await GetAzureAccessToken(_setting.TenantId, _setting.ClientId, _setting.ClientSecret);
            string url = $"https://management.azure.com/subscriptions/{_setting.SubscriptionId}/resourceGroups/{_setting.ResourceGroup}/providers/Microsoft.Compute/virtualMachines/{instanceId}?api-version=2023-01-01";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    static async Task<string?> GetAzureAccessToken(string? tenantId, string? clientId, string? clientSecret)
    {
        using var client = new HttpClient();
        var url = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token";

        var body = new StringContent(
            $"client_id={clientId}&client_secret={clientSecret}&grant_type=client_credentials&scope=https://management.azure.com/.default",
            Encoding.UTF8, "application/x-www-form-urlencoded");

        HttpResponseMessage response = await client.PostAsync(url, body);
        string json = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(json);
        return doc.RootElement.GetProperty("access_token").GetString();
    }
}
