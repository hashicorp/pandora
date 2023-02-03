using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2021_06_01.Redis;


internal class RedisInstanceDetailsModel
{
    [JsonPropertyName("isMaster")]
    public bool? IsMaster { get; set; }

    [JsonPropertyName("isPrimary")]
    public bool? IsPrimary { get; set; }

    [JsonPropertyName("nonSslPort")]
    public int? NonSslPort { get; set; }

    [JsonPropertyName("shardId")]
    public int? ShardId { get; set; }

    [JsonPropertyName("sslPort")]
    public int? SslPort { get; set; }

    [JsonPropertyName("zone")]
    public CustomTypes.Zone? Zone { get; set; }
}
