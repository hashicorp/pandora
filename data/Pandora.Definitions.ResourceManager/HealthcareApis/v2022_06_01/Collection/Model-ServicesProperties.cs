using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2022_06_01.Collection;


internal class ServicesPropertiesModel
{
    [JsonPropertyName("accessPolicies")]
    public List<ServiceAccessPolicyEntryModel>? AccessPolicies { get; set; }

    [JsonPropertyName("acrConfiguration")]
    public ServiceAcrConfigurationInfoModel? AcrConfiguration { get; set; }

    [JsonPropertyName("authenticationConfiguration")]
    public ServiceAuthenticationConfigurationInfoModel? AuthenticationConfiguration { get; set; }

    [JsonPropertyName("corsConfiguration")]
    public ServiceCorsConfigurationInfoModel? CorsConfiguration { get; set; }

    [JsonPropertyName("cosmosDbConfiguration")]
    public ServiceCosmosDbConfigurationInfoModel? CosmosDbConfiguration { get; set; }

    [JsonPropertyName("exportConfiguration")]
    public ServiceExportConfigurationInfoModel? ExportConfiguration { get; set; }

    [JsonPropertyName("importConfiguration")]
    public ServiceImportConfigurationInfoModel? ImportConfiguration { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }
}
