using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.RegistryManagement;


internal class RegistryModel
{
    [JsonPropertyName("discoveryUrl")]
    public string? DiscoveryUrl { get; set; }

    [JsonPropertyName("intellectualPropertyPublisher")]
    public string? IntellectualPropertyPublisher { get; set; }

    [JsonPropertyName("managedResourceGroup")]
    public ArmResourceIdModel? ManagedResourceGroup { get; set; }

    [JsonPropertyName("mlFlowRegistryUri")]
    public string? MlFlowRegistryUri { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<RegistryPrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public string? PublicNetworkAccess { get; set; }

    [JsonPropertyName("regionDetails")]
    public List<RegistryRegionArmDetailsModel>? RegionDetails { get; set; }
}
