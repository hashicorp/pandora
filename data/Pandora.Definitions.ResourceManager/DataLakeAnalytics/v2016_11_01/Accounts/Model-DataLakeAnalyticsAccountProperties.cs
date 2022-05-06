using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Accounts;


internal class DataLakeAnalyticsAccountPropertiesModel
{
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("computePolicies")]
    public List<ComputePolicyModel>? ComputePolicies { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("currentTier")]
    public TierTypeConstant? CurrentTier { get; set; }

    [JsonPropertyName("dataLakeStoreAccounts")]
    public List<DataLakeStoreAccountInformationModel>? DataLakeStoreAccounts { get; set; }

    [JsonPropertyName("debugDataAccessLevel")]
    public DebugDataAccessLevelConstant? DebugDataAccessLevel { get; set; }

    [JsonPropertyName("defaultDataLakeStoreAccount")]
    public string? DefaultDataLakeStoreAccount { get; set; }

    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    [JsonPropertyName("firewallAllowAzureIps")]
    public FirewallAllowAzureIpsStateConstant? FirewallAllowAzureIps { get; set; }

    [JsonPropertyName("firewallRules")]
    public List<FirewallRuleModel>? FirewallRules { get; set; }

    [JsonPropertyName("firewallState")]
    public FirewallStateConstant? FirewallState { get; set; }

    [JsonPropertyName("hiveMetastores")]
    public List<HiveMetastoreModel>? HiveMetastores { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("maxActiveJobCountPerUser")]
    public int? MaxActiveJobCountPerUser { get; set; }

    [JsonPropertyName("maxDegreeOfParallelism")]
    public int? MaxDegreeOfParallelism { get; set; }

    [JsonPropertyName("maxDegreeOfParallelismPerJob")]
    public int? MaxDegreeOfParallelismPerJob { get; set; }

    [JsonPropertyName("maxJobCount")]
    public int? MaxJobCount { get; set; }

    [JsonPropertyName("maxJobRunningTimeInMin")]
    public int? MaxJobRunningTimeInMin { get; set; }

    [JsonPropertyName("maxQueuedJobCountPerUser")]
    public int? MaxQueuedJobCountPerUser { get; set; }

    [JsonPropertyName("minPriorityPerJob")]
    public int? MinPriorityPerJob { get; set; }

    [JsonPropertyName("newTier")]
    public TierTypeConstant? NewTier { get; set; }

    [JsonPropertyName("provisioningState")]
    public DataLakeAnalyticsAccountStatusConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicDataLakeStoreAccounts")]
    public List<DataLakeStoreAccountInformationModel>? PublicDataLakeStoreAccounts { get; set; }

    [JsonPropertyName("queryStoreRetention")]
    public int? QueryStoreRetention { get; set; }

    [JsonPropertyName("state")]
    public DataLakeAnalyticsAccountStateConstant? State { get; set; }

    [JsonPropertyName("storageAccounts")]
    public List<StorageAccountInformationModel>? StorageAccounts { get; set; }

    [JsonPropertyName("systemMaxDegreeOfParallelism")]
    public int? SystemMaxDegreeOfParallelism { get; set; }

    [JsonPropertyName("systemMaxJobCount")]
    public int? SystemMaxJobCount { get; set; }

    [JsonPropertyName("virtualNetworkRules")]
    public List<VirtualNetworkRuleModel>? VirtualNetworkRules { get; set; }
}
