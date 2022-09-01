using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ManagedAPIs;


internal class ApiResourcePropertiesModel
{
    [JsonPropertyName("apiDefinitionUrl")]
    public string? ApiDefinitionUrl { get; set; }

    [JsonPropertyName("apiDefinitions")]
    public ApiResourceDefinitionsModel? ApiDefinitions { get; set; }

    [JsonPropertyName("backendService")]
    public ApiResourceBackendServiceModel? BackendService { get; set; }

    [JsonPropertyName("capabilities")]
    public List<string>? Capabilities { get; set; }

    [JsonPropertyName("connectionParameters")]
    public Dictionary<string, ConnectionParameterModel>? ConnectionParameters { get; set; }

    [JsonPropertyName("generalInformation")]
    public ApiResourceGeneralInformationModel? GeneralInformation { get; set; }

    [JsonPropertyName("metadata")]
    public ApiResourceMetadataModel? Metadata { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("policies")]
    public ApiResourcePoliciesModel? Policies { get; set; }

    [JsonPropertyName("runtimeUrls")]
    public List<string>? RuntimeUrls { get; set; }

    [JsonPropertyName("swagger")]
    public object? Swagger { get; set; }
}
