using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.GalleryImageVersions;


internal class TargetRegionModel
{
    [JsonPropertyName("encryption")]
    public EncryptionImagesModel? Encryption { get; set; }

    [JsonPropertyName("excludeFromLatest")]
    public bool? ExcludeFromLatest { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("regionalReplicaCount")]
    public int? RegionalReplicaCount { get; set; }

    [JsonPropertyName("storageAccountType")]
    public StorageAccountTypeConstant? StorageAccountType { get; set; }
}
