using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.ManagedClusterSnapshots;


internal class ManagedClusterSnapshotPropertiesModel
{
    [JsonPropertyName("creationData")]
    public CreationDataModel? CreationData { get; set; }

    [JsonPropertyName("managedClusterPropertiesReadOnly")]
    public ManagedClusterPropertiesForSnapshotModel? ManagedClusterPropertiesReadOnly { get; set; }

    [JsonPropertyName("snapshotType")]
    public SnapshotTypeConstant? SnapshotType { get; set; }
}
