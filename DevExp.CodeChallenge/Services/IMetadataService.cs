namespace DevExp.CodeChallenge.Services;

internal interface IMetadataService
{
    Task<string> GetMetadataAsync(string instanceId);
}
