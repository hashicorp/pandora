using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationMigrationItems;


internal class VMwareCbtUpdateDiskInputModel
{
    [JsonPropertyName("diskId")]
    [Required]
    public string DiskId { get; set; }

    [JsonPropertyName("isOSDisk")]
    public string? IsOSDisk { get; set; }

    [JsonPropertyName("targetDiskName")]
    public string? TargetDiskName { get; set; }
}
