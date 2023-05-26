using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.GalleryApplicationVersions;


internal class GalleryApplicationVersionPropertiesModel
{
    [JsonPropertyName("provisioningState")]
    public GalleryProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publishingProfile")]
    [Required]
    public GalleryApplicationVersionPublishingProfileModel PublishingProfile { get; set; }

    [JsonPropertyName("replicationStatus")]
    public ReplicationStatusModel? ReplicationStatus { get; set; }

    [JsonPropertyName("safetyProfile")]
    public GalleryArtifactSafetyProfileBaseModel? SafetyProfile { get; set; }
}
