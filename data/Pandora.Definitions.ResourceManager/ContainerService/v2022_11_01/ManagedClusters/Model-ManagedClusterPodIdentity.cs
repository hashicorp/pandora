using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_11_01.ManagedClusters;


internal class ManagedClusterPodIdentityModel
{
    [JsonPropertyName("bindingSelector")]
    public string? BindingSelector { get; set; }

    [JsonPropertyName("identity")]
    [Required]
    public UserAssignedIdentityModel Identity { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("namespace")]
    [Required]
    public string Namespace { get; set; }

    [JsonPropertyName("provisioningInfo")]
    public ManagedClusterPodIdentityProvisioningInfoModel? ProvisioningInfo { get; set; }

    [JsonPropertyName("provisioningState")]
    public ManagedClusterPodIdentityProvisioningStateConstant? ProvisioningState { get; set; }
}
