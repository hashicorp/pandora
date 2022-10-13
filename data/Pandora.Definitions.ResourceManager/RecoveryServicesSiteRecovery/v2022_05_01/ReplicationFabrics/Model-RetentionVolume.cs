using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationFabrics;


internal class RetentionVolumeModel
{
    [JsonPropertyName("capacityInBytes")]
    public int? CapacityInBytes { get; set; }

    [JsonPropertyName("freeSpaceInBytes")]
    public int? FreeSpaceInBytes { get; set; }

    [JsonPropertyName("thresholdPercentage")]
    public int? ThresholdPercentage { get; set; }

    [JsonPropertyName("volumeName")]
    public string? VolumeName { get; set; }
}
