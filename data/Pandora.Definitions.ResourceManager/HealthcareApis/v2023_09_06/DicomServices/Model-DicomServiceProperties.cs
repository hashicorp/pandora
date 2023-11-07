using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2023_09_06.DicomServices;


internal class DicomServicePropertiesModel
{
    [JsonPropertyName("authenticationConfiguration")]
    public DicomServiceAuthenticationConfigurationModel? AuthenticationConfiguration { get; set; }

    [JsonPropertyName("corsConfiguration")]
    public CorsConfigurationModel? CorsConfiguration { get; set; }

    [JsonPropertyName("eventState")]
    public ServiceEventStateConstant? EventState { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("serviceUrl")]
    public string? ServiceUrl { get; set; }
}
