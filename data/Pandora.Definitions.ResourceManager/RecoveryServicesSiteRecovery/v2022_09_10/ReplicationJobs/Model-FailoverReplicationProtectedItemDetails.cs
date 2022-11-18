using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationJobs;


internal class FailoverReplicationProtectedItemDetailsModel
{
    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("networkConnectionStatus")]
    public string? NetworkConnectionStatus { get; set; }

    [JsonPropertyName("networkFriendlyName")]
    public string? NetworkFriendlyName { get; set; }

    [JsonPropertyName("recoveryPointId")]
    public string? RecoveryPointId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("recoveryPointTime")]
    public DateTime? RecoveryPointTime { get; set; }

    [JsonPropertyName("subnet")]
    public string? Subnet { get; set; }

    [JsonPropertyName("testVmFriendlyName")]
    public string? TestVmFriendlyName { get; set; }

    [JsonPropertyName("testVmName")]
    public string? TestVmName { get; set; }
}
