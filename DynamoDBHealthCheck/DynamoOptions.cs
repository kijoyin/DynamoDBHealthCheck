using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoDBHealthCheck
{
    public class DynamoOptions
    {
        public string AWSAcessKey { get; set; }
        public string AWSSecretKey { get; set; }
        public string ConnectionString { get; set; }
        public string AuthenticationRegion { get; set; }
        public string TableName { get; set; }
        public bool UseLocalDb { get; set; }
    }
}
