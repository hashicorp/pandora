using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.GalleryImageVersions;


internal class GalleryDataDiskImageModel
{
    [JsonPropertyName("hostCaching")]
    public HostCachingConstant? HostCaching { get; set; }

    [JsonPropertyName("lun")]
    [Required]
    public int Lun { get; set; }

    [JsonPropertyName("sizeInGB")]
    public int? SizeInGB { get; set; }

    [JsonPropertyName("source")]
    public GalleryArtifactVersionSourceModel? Source { get; set; }
}
