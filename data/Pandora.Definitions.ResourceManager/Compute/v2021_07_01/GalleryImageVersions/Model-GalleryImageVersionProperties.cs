using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.GalleryImageVersions;


internal class GalleryImageVersionPropertiesModel
{
    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publishingProfile")]
    public GalleryArtifactPublishingProfileBaseModel? PublishingProfile { get; set; }

    [JsonPropertyName("replicationStatus")]
    public ReplicationStatusModel? ReplicationStatus { get; set; }

    [JsonPropertyName("storageProfile")]
    [Required]
    public GalleryImageVersionStorageProfileModel StorageProfile { get; set; }
}
