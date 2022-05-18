using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsRevisions;


internal class TemplateModel
{
    [JsonPropertyName("containers")]
    public List<ContainerModel>? Containers { get; set; }

    [JsonPropertyName("revisionSuffix")]
    public string? RevisionSuffix { get; set; }

    [JsonPropertyName("scale")]
    public ScaleModel? Scale { get; set; }

    [JsonPropertyName("volumes")]
    public List<VolumeModel>? Volumes { get; set; }
}
