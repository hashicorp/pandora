using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.Images;


internal class ImageOSDiskModel
{
    [JsonPropertyName("blobUri")]
    public string? BlobUri { get; set; }

    [JsonPropertyName("caching")]
    public CachingTypesConstant? Caching { get; set; }

    [JsonPropertyName("diskEncryptionSet")]
    public SubResourceModel? DiskEncryptionSet { get; set; }

    [JsonPropertyName("diskSizeGB")]
    public int? DiskSizeGB { get; set; }

    [JsonPropertyName("managedDisk")]
    public SubResourceModel? ManagedDisk { get; set; }

    [JsonPropertyName("osState")]
    [Required]
    public OperatingSystemStateTypesConstant OsState { get; set; }

    [JsonPropertyName("osType")]
    [Required]
    public OperatingSystemTypesConstant OsType { get; set; }

    [JsonPropertyName("snapshot")]
    public SubResourceModel? Snapshot { get; set; }

    [JsonPropertyName("storageAccountType")]
    public StorageAccountTypesConstant? StorageAccountType { get; set; }
}
