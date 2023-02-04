using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2022_06_01.Redis;


internal class RedisPropertiesModel
{
    [JsonPropertyName("accessKeys")]
    public RedisAccessKeysModel? AccessKeys { get; set; }

    [JsonPropertyName("enableNonSslPort")]
    public bool? EnableNonSslPort { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("instances")]
    public List<RedisInstanceDetailsModel>? Instances { get; set; }

    [JsonPropertyName("linkedServers")]
    public List<RedisLinkedServerModel>? LinkedServers { get; set; }

    [JsonPropertyName("minimumTlsVersion")]
    public TlsVersionConstant? MinimumTlsVersion { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("redisConfiguration")]
    public RedisCommonPropertiesRedisConfigurationModel? RedisConfiguration { get; set; }

    [JsonPropertyName("redisVersion")]
    public string? RedisVersion { get; set; }

    [JsonPropertyName("replicasPerMaster")]
    public int? ReplicasPerMaster { get; set; }

    [JsonPropertyName("replicasPerPrimary")]
    public int? ReplicasPerPrimary { get; set; }

    [JsonPropertyName("shardCount")]
    public int? ShardCount { get; set; }

    [JsonPropertyName("sku")]
    [Required]
    public SkuModel Sku { get; set; }

    [JsonPropertyName("sslPort")]
    public int? SslPort { get; set; }

    [JsonPropertyName("staticIP")]
    public string? StaticIP { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }

    [JsonPropertyName("tenantSettings")]
    public Dictionary<string, string>? TenantSettings { get; set; }
}
