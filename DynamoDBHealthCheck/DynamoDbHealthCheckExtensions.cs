using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoDBHealthCheck
{
    public static class DynamoDbHealthCheckExtensions
    {
        const string NAME = "dynamodb";
        public static IHealthChecksBuilder AddDynamoDb(this IHealthChecksBuilder builder, Action<DynamoOptions> setup, string name = default, HealthStatus? failureStatus = default, IEnumerable<string> tags = default, TimeSpan? timeout = default)
        {
            var options = new DynamoOptions();
            setup?.Invoke(options);

            return builder.Add(new HealthCheckRegistration(
                name ?? NAME,
                sp => new DynamoHealth(options),
                failureStatus,
                tags,
                timeout));
        }
    }
}
