using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PrivateDNS.v2018_09_01.RecordSets;


internal class SoaRecordModel
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("expireTime")]
    public int? ExpireTime { get; set; }

    [JsonPropertyName("host")]
    public string? Host { get; set; }

    [JsonPropertyName("minimumTtl")]
    public int? MinimumTtl { get; set; }

    [JsonPropertyName("refreshTime")]
    public int? RefreshTime { get; set; }

    [JsonPropertyName("retryTime")]
    public int? RetryTime { get; set; }

    [JsonPropertyName("serialNumber")]
    public int? SerialNumber { get; set; }
}
