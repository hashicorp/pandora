using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ConnectionGateways;


internal class ConnectionGatewayInstallationDefinitionPropertiesModel
{
    [JsonPropertyName("backendUri")]
    public string? BackendUri { get; set; }

    [JsonPropertyName("connectionGateway")]
    public ConnectionGatewayReferenceModel? ConnectionGateway { get; set; }

    [JsonPropertyName("contactInformation")]
    public List<string>? ContactInformation { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("machineName")]
    public string? MachineName { get; set; }

    [JsonPropertyName("status")]
    public object? Status { get; set; }
}
