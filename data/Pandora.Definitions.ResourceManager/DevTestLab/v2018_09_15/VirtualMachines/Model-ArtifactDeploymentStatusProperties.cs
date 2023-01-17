using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.VirtualMachines;


internal class ArtifactDeploymentStatusPropertiesModel
{
    [JsonPropertyName("artifactsApplied")]
    public int? ArtifactsApplied { get; set; }

    [JsonPropertyName("deploymentStatus")]
    public string? DeploymentStatus { get; set; }

    [JsonPropertyName("totalArtifacts")]
    public int? TotalArtifacts { get; set; }
}
