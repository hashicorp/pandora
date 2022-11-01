using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.ManagedClusters;


internal class ManagedClusterPodIdentityProfileModel
{
    [JsonPropertyName("allowNetworkPluginKubenet")]
    public bool? AllowNetworkPluginKubenet { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("userAssignedIdentities")]
    public List<ManagedClusterPodIdentityModel>? UserAssignedIdentities { get; set; }

    [JsonPropertyName("userAssignedIdentityExceptions")]
    public List<ManagedClusterPodIdentityExceptionModel>? UserAssignedIdentityExceptions { get; set; }
}
