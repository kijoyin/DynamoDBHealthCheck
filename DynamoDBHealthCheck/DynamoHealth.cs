using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DynamoDBHealthCheck
{
    public class DynamoHealth: IHealthCheck
    {
        private readonly DynamoOptions _options;
        public DynamoHealth(DynamoOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var credentials = new BasicAWSCredentials(_options.AWSAcessKey, _options.AWSSecretKey);
                var config = new AmazonDynamoDBConfig();
                config.AuthenticationRegion = _options.AuthenticationRegion;
                config.ServiceURL = _options.ConnectionString;
                var client = new AmazonDynamoDBClient(credentials, config);
                await client.DescribeTableAsync(_options.TableName,cancellationToken);
                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }
        }
    }
}
