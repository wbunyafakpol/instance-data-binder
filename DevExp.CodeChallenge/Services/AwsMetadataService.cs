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
            var awsCredentials = new BasicAWSCredentials(setting.AccessKey, setting.SecretKey);
            _ec2Client = new AmazonEC2Client(awsCredentials, RegionEndpoint.GetBySystemName(setting.Region));
        }
        public async Task<string> GetMetadataAsync(string instanceId)
        {
            try
            {
                var response = await _ec2Client.DescribeInstancesAsync(new DescribeInstancesRequest
                {
                    InstanceIds = new List<string> { instanceId }
                });

                return JsonSerializer.Serialize(response.Reservations.FirstOrDefault());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
