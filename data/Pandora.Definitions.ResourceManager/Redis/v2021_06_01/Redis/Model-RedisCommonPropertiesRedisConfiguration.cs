using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2021_06_01.Redis;


internal class RedisCommonPropertiesRedisConfigurationModel
{
    [JsonPropertyName("aof-backup-enabled")]
    public string? AofBackupEnabled { get; set; }

    [JsonPropertyName("aof-storage-connection-string-0")]
    public string? AofStorageConnectionString0 { get; set; }

    [JsonPropertyName("aof-storage-connection-string-1")]
    public string? AofStorageConnectionString1 { get; set; }

    [JsonPropertyName("authnotrequired")]
    public string? Authnotrequired { get; set; }

    [JsonPropertyName("maxclients")]
    public string? Maxclients { get; set; }

    [JsonPropertyName("maxfragmentationmemory-reserved")]
    public string? MaxfragmentationmemoryReserved { get; set; }

    [JsonPropertyName("maxmemory-delta")]
    public string? MaxmemoryDelta { get; set; }

    [JsonPropertyName("maxmemory-policy")]
    public string? MaxmemoryPolicy { get; set; }

    [JsonPropertyName("maxmemory-reserved")]
    public string? MaxmemoryReserved { get; set; }

    [JsonPropertyName("notify-keyspace-events")]
    public string? NotifyKeyspaceEvents { get; set; }

    [JsonPropertyName("preferred-data-archive-auth-method")]
    public string? PreferredDataArchiveAuthMethod { get; set; }

    [JsonPropertyName("preferred-data-persistence-auth-method")]
    public string? PreferredDataPersistenceAuthMethod { get; set; }

    [JsonPropertyName("rdb-backup-enabled")]
    public string? RdbBackupEnabled { get; set; }

    [JsonPropertyName("rdb-backup-frequency")]
    public string? RdbBackupFrequency { get; set; }

    [JsonPropertyName("rdb-backup-max-snapshot-count")]
    public string? RdbBackupMaxSnapshotCount { get; set; }

    [JsonPropertyName("rdb-storage-connection-string")]
    public string? RdbStorageConnectionString { get; set; }

    [JsonPropertyName("zonal-configuration")]
    public string? ZonalConfiguration { get; set; }
}
