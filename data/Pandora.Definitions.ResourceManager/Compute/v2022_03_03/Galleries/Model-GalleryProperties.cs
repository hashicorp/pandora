using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.Galleries;


internal class GalleryPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("identifier")]
    public GalleryIdentifierModel? Identifier { get; set; }

    [JsonPropertyName("provisioningState")]
    public GalleryProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sharingProfile")]
    public SharingProfileModel? SharingProfile { get; set; }

    [JsonPropertyName("sharingStatus")]
    public SharingStatusModel? SharingStatus { get; set; }

    [JsonPropertyName("softDeletePolicy")]
    public SoftDeletePolicyModel? SoftDeletePolicy { get; set; }
}
