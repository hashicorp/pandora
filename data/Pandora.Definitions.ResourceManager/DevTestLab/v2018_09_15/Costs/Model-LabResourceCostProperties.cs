using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Costs;


internal class LabResourceCostPropertiesModel
{
    [JsonPropertyName("externalResourceId")]
    public string? ExternalResourceId { get; set; }

    [JsonPropertyName("resourceCost")]
    public float? ResourceCost { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("resourceOwner")]
    public string? ResourceOwner { get; set; }

    [JsonPropertyName("resourcePricingTier")]
    public string? ResourcePricingTier { get; set; }

    [JsonPropertyName("resourceStatus")]
    public string? ResourceStatus { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("resourceUId")]
    public string? ResourceUId { get; set; }

    [JsonPropertyName("resourcename")]
    public string? Resourcename { get; set; }
}
