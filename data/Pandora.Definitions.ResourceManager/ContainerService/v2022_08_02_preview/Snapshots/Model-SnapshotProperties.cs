using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_08_02_preview.Snapshots;


internal class SnapshotPropertiesModel
{
    [JsonPropertyName("creationData")]
    public CreationDataModel? CreationData { get; set; }

    [JsonPropertyName("enableFIPS")]
    public bool? EnableFIPS { get; set; }

    [JsonPropertyName("kubernetesVersion")]
    public string? KubernetesVersion { get; set; }

    [JsonPropertyName("nodeImageVersion")]
    public string? NodeImageVersion { get; set; }

    [JsonPropertyName("osSku")]
    public OSSKUConstant? OsSku { get; set; }

    [JsonPropertyName("osType")]
    public OSTypeConstant? OsType { get; set; }

    [JsonPropertyName("snapshotType")]
    public SnapshotTypeConstant? SnapshotType { get; set; }

    [JsonPropertyName("vmSize")]
    public string? VmSize { get; set; }
}
