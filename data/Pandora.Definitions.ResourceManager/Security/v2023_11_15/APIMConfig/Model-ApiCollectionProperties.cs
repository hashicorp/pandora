using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2023_11_15.APIMConfig;


internal class ApiCollectionPropertiesModel
{
    [JsonPropertyName("baseUrl")]
    public string? BaseUrl { get; set; }

    [JsonPropertyName("discoveredVia")]
    public string? DiscoveredVia { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("numberOfApiEndpoints")]
    public int? NumberOfApiEndpoints { get; set; }

    [JsonPropertyName("numberOfApiEndpointsWithSensitiveDataExposed")]
    public int? NumberOfApiEndpointsWithSensitiveDataExposed { get; set; }

    [JsonPropertyName("numberOfExternalApiEndpoints")]
    public int? NumberOfExternalApiEndpoints { get; set; }

    [JsonPropertyName("numberOfInactiveApiEndpoints")]
    public int? NumberOfInactiveApiEndpoints { get; set; }

    [JsonPropertyName("numberOfUnauthenticatedApiEndpoints")]
    public int? NumberOfUnauthenticatedApiEndpoints { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sensitivityLabel")]
    public string? SensitivityLabel { get; set; }
}
