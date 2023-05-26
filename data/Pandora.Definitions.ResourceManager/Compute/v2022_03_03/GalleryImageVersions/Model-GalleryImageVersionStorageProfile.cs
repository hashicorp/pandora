using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.GalleryImageVersions;


internal class GalleryImageVersionStorageProfileModel
{
    [JsonPropertyName("dataDiskImages")]
    public List<GalleryDataDiskImageModel>? DataDiskImages { get; set; }

    [JsonPropertyName("osDiskImage")]
    public GalleryDiskImageModel? OsDiskImage { get; set; }

    [JsonPropertyName("source")]
    public GalleryArtifactVersionFullSourceModel? Source { get; set; }
}
