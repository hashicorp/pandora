using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2022_06_01.Redis;


internal class RedisCreatePropertiesModel
{
    [JsonPropertyName("enableNonSslPort")]
    public bool? EnableNonSslPort { get; set; }

    [JsonPropertyName("minimumTlsVersion")]
    public TlsVersionConstant? MinimumTlsVersion { get; set; }

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

    [JsonPropertyName("staticIP")]
    public string? StaticIP { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }

    [JsonPropertyName("tenantSettings")]
    public Dictionary<string, string>? TenantSettings { get; set; }
}
