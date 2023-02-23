using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.SnapshotPolicyListVolumes;


internal class VolumeBackupPropertiesModel
{
    [JsonPropertyName("backupEnabled")]
    public bool? BackupEnabled { get; set; }

    [JsonPropertyName("backupPolicyId")]
    public string? BackupPolicyId { get; set; }

    [JsonPropertyName("policyEnforced")]
    public bool? PolicyEnforced { get; set; }
}
