using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Accounts
{

    internal class CreateDataLakeAnalyticsAccountPropertiesModel
    {
        [JsonPropertyName("computePolicies")]
        public List<CreateComputePolicyWithAccountParametersModel>? ComputePolicies { get; set; }

        [JsonPropertyName("dataLakeStoreAccounts")]
        [Required]
        public List<AddDataLakeStoreWithAccountParametersModel> DataLakeStoreAccounts { get; set; }

        [JsonPropertyName("defaultDataLakeStoreAccount")]
        [Required]
        public string DefaultDataLakeStoreAccount { get; set; }

        [JsonPropertyName("firewallAllowAzureIps")]
        public FirewallAllowAzureIpsStateConstant? FirewallAllowAzureIps { get; set; }

        [JsonPropertyName("firewallRules")]
        public List<CreateFirewallRuleWithAccountParametersModel>? FirewallRules { get; set; }

        [JsonPropertyName("firewallState")]
        public FirewallStateConstant? FirewallState { get; set; }

        [JsonPropertyName("maxDegreeOfParallelism")]
        public int? MaxDegreeOfParallelism { get; set; }

        [JsonPropertyName("maxDegreeOfParallelismPerJob")]
        public int? MaxDegreeOfParallelismPerJob { get; set; }

        [JsonPropertyName("maxJobCount")]
        public int? MaxJobCount { get; set; }

        [JsonPropertyName("minPriorityPerJob")]
        public int? MinPriorityPerJob { get; set; }

        [JsonPropertyName("newTier")]
        public TierTypeConstant? NewTier { get; set; }

        [JsonPropertyName("queryStoreRetention")]
        public int? QueryStoreRetention { get; set; }

        [JsonPropertyName("storageAccounts")]
        public List<AddStorageAccountWithAccountParametersModel>? StorageAccounts { get; set; }
    }
}
