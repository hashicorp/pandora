using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.GalleryImageVersions;


internal class GalleryTargetExtendedLocationModel
{
    [JsonPropertyName("encryption")]
    public EncryptionImagesModel? Encryption { get; set; }

    [JsonPropertyName("extendedLocation")]
    public GalleryExtendedLocationModel? ExtendedLocation { get; set; }

    [JsonPropertyName("extendedLocationReplicaCount")]
    public int? ExtendedLocationReplicaCount { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("storageAccountType")]
    public EdgeZoneStorageAccountTypeConstant? StorageAccountType { get; set; }
}
