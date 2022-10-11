using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_03_10.PrivateLinkScopes;


internal class HybridComputePrivateLinkScopePropertiesModel
{
    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionDataModelModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("privateLinkScopeId")]
    public string? PrivateLinkScopeId { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessTypeConstant? PublicNetworkAccess { get; set; }
}
