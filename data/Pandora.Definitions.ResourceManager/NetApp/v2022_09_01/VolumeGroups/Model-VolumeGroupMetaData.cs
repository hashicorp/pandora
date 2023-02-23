using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.VolumeGroups;


internal class VolumeGroupMetaDataModel
{
    [JsonPropertyName("applicationIdentifier")]
    public string? ApplicationIdentifier { get; set; }

    [JsonPropertyName("applicationType")]
    public ApplicationTypeConstant? ApplicationType { get; set; }

    [JsonPropertyName("deploymentSpecId")]
    public string? DeploymentSpecId { get; set; }

    [JsonPropertyName("globalPlacementRules")]
    public List<PlacementKeyValuePairsModel>? GlobalPlacementRules { get; set; }

    [JsonPropertyName("groupDescription")]
    public string? GroupDescription { get; set; }

    [JsonPropertyName("volumesCount")]
    public int? VolumesCount { get; set; }
}
