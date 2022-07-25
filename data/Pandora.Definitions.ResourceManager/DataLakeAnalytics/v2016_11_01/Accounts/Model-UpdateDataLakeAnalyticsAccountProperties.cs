using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Accounts;


internal class UpdateDataLakeAnalyticsAccountPropertiesModel
{
    [JsonPropertyName("computePolicies")]
    public List<UpdateComputePolicyWithAccountParametersModel>? ComputePolicies { get; set; }

    [JsonPropertyName("dataLakeStoreAccounts")]
    public List<UpdateDataLakeStoreWithAccountParametersModel>? DataLakeStoreAccounts { get; set; }

    [JsonPropertyName("firewallAllowAzureIps")]
    public FirewallAllowAzureIPsStateConstant? FirewallAllowAzureIPs { get; set; }

    [JsonPropertyName("firewallRules")]
    public List<UpdateFirewallRuleWithAccountParametersModel>? FirewallRules { get; set; }

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
    public List<UpdateStorageAccountWithAccountParametersModel>? StorageAccounts { get; set; }
}
