using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.RegistryManagement;


internal class RegistryPrivateEndpointConnectionPropertiesModel
{
    [JsonPropertyName("groupIds")]
    public List<string>? GroupIds { get; set; }

    [JsonPropertyName("privateEndpoint")]
    public PrivateEndpointResourceModel? PrivateEndpoint { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("registryPrivateLinkServiceConnectionState")]
    public RegistryPrivateLinkServiceConnectionStateModel? RegistryPrivateLinkServiceConnectionState { get; set; }
}
