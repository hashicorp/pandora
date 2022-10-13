using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectableItems;


internal class InMageDiskDetailsModel
{
    [JsonPropertyName("diskConfiguration")]
    public string? DiskConfiguration { get; set; }

    [JsonPropertyName("diskId")]
    public string? DiskId { get; set; }

    [JsonPropertyName("diskName")]
    public string? DiskName { get; set; }

    [JsonPropertyName("diskSizeInMB")]
    public string? DiskSizeInMB { get; set; }

    [JsonPropertyName("diskType")]
    public string? DiskType { get; set; }

    [JsonPropertyName("volumeList")]
    public List<DiskVolumeDetailsModel>? VolumeList { get; set; }
}
