using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dashboard.v2023_09_01.ManagedPrivateEndpoints;


internal class ManagedPrivateEndpointModelPropertiesModel
{
    [JsonPropertyName("connectionState")]
    public ManagedPrivateEndpointConnectionStateModel? ConnectionState { get; set; }

    [JsonPropertyName("groupIds")]
    public List<string>? GroupIds { get; set; }

    [JsonPropertyName("privateLinkResourceId")]
    public string? PrivateLinkResourceId { get; set; }

    [JsonPropertyName("privateLinkResourceRegion")]
    public string? PrivateLinkResourceRegion { get; set; }

    [JsonPropertyName("privateLinkServicePrivateIP")]
    public string? PrivateLinkServicePrivateIP { get; set; }

    [JsonPropertyName("privateLinkServiceUrl")]
    public string? PrivateLinkServiceUrl { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("requestMessage")]
    public string? RequestMessage { get; set; }
}
