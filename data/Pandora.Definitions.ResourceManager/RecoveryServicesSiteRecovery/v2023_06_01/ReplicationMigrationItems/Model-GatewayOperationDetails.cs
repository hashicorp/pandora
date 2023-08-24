using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_06_01.ReplicationMigrationItems;


internal class GatewayOperationDetailsModel
{
    [JsonPropertyName("dataStores")]
    public List<string>? DataStores { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("progressPercentage")]
    public int? ProgressPercentage { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("timeElapsed")]
    public int? TimeElapsed { get; set; }

    [JsonPropertyName("timeRemaining")]
    public int? TimeRemaining { get; set; }

    [JsonPropertyName("uploadSpeed")]
    public int? UploadSpeed { get; set; }

    [JsonPropertyName("vmwareReadThroughput")]
    public int? VMwareReadThroughput { get; set; }
}
