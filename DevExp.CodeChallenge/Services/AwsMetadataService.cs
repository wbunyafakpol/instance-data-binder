using System.Text.Json;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;
using DevExp.CodeChallenge.Configurations;

namespace DevExp.CodeChallenge.Services
{
    internal class AwsMetadataService : IMetadataService
    {
        private readonly AmazonEC2Client _ec2Client;
        public AwsMetadataService(AwsSetting setting)
        {
            
        }
        public async Task<string> GetMetadataAsync(string instanceId)
        {
           
        }
    }
}
