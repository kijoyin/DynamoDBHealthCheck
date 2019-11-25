using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;

namespace DynamoDBHealthCheck
{
    public static class DynamoDbHealthCheckExtensions
    {
        const string NAME = "dynamodb";
        public static IHealthChecksBuilder AddDynamoDb(this IHealthChecksBuilder builder, DynamoOptions options, string name = default, HealthStatus? failureStatus = default, IEnumerable<string> tags = default, TimeSpan? timeout = default)
        {
            return builder.Add(new HealthCheckRegistration(
                name ?? NAME,
                sp => new DynamoHealth(options),
                failureStatus,
                tags,
                timeout));
        }
    }
}
