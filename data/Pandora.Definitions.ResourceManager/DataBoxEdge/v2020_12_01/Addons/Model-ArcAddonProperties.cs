using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Addons;


internal class ArcAddonPropertiesModel
{
    [JsonPropertyName("hostPlatform")]
    public PlatformTypeConstant? HostPlatform { get; set; }

    [JsonPropertyName("hostPlatformType")]
    public HostPlatformTypeConstant? HostPlatformType { get; set; }

    [JsonPropertyName("provisioningState")]
    public AddonStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceGroupName")]
    [Required]
    public string ResourceGroupName { get; set; }

    [JsonPropertyName("resourceLocation")]
    [Required]
    public string ResourceLocation { get; set; }

    [JsonPropertyName("resourceName")]
    [Required]
    public string ResourceName { get; set; }

    [JsonPropertyName("subscriptionId")]
    [Required]
    public string SubscriptionId { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
