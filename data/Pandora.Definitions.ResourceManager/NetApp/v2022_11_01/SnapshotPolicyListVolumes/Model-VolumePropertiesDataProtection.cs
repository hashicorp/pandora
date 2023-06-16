using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01.SnapshotPolicyListVolumes;


internal class VolumePropertiesDataProtectionModel
{
    [JsonPropertyName("backup")]
    public VolumeBackupPropertiesModel? Backup { get; set; }

    [JsonPropertyName("replication")]
    public ReplicationObjectModel? Replication { get; set; }

    [JsonPropertyName("snapshot")]
    public VolumeSnapshotPropertiesModel? Snapshot { get; set; }

    [JsonPropertyName("volumeRelocation")]
    public VolumeRelocationPropertiesModel? VolumeRelocation { get; set; }
}
