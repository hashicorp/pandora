using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_02.Snapshots;


internal class CreationDataModel
{
    [JsonPropertyName("createOption")]
    [Required]
    public DiskCreateOptionConstant CreateOption { get; set; }

    [JsonPropertyName("galleryImageReference")]
    public ImageDiskReferenceModel? GalleryImageReference { get; set; }

    [JsonPropertyName("imageReference")]
    public ImageDiskReferenceModel? ImageReference { get; set; }

    [JsonPropertyName("logicalSectorSize")]
    public int? LogicalSectorSize { get; set; }

    [JsonPropertyName("securityDataUri")]
    public string? SecurityDataUri { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("sourceUniqueId")]
    public string? SourceUniqueId { get; set; }

    [JsonPropertyName("sourceUri")]
    public string? SourceUri { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }

    [JsonPropertyName("uploadSizeBytes")]
    public int? UploadSizeBytes { get; set; }
}
