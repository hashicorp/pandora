using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerApps;


internal class TrafficWeightModel
{
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("latestRevision")]
    public bool? LatestRevision { get; set; }

    [JsonPropertyName("revisionName")]
    public string? RevisionName { get; set; }

    [JsonPropertyName("weight")]
    public int? Weight { get; set; }
}
