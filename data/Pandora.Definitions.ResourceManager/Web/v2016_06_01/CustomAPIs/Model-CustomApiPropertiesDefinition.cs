using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.CustomAPIs;


internal class CustomApiPropertiesDefinitionModel
{
    [JsonPropertyName("apiDefinitions")]
    public ApiResourceDefinitionsModel? ApiDefinitions { get; set; }

    [JsonPropertyName("apiType")]
    public ApiTypeConstant? ApiType { get; set; }

    [JsonPropertyName("backendService")]
    public ApiResourceBackendServiceModel? BackendService { get; set; }

    [JsonPropertyName("brandColor")]
    public string? BrandColor { get; set; }

    [JsonPropertyName("capabilities")]
    public List<string>? Capabilities { get; set; }

    [JsonPropertyName("connectionParameters")]
    public Dictionary<string, ConnectionParameterModel>? ConnectionParameters { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("iconUri")]
    public string? IconUri { get; set; }

    [JsonPropertyName("runtimeUrls")]
    public List<string>? RuntimeUrls { get; set; }

    [JsonPropertyName("swagger")]
    public object? Swagger { get; set; }

    [JsonPropertyName("wsdlDefinition")]
    public WsdlDefinitionModel? WsdlDefinition { get; set; }
}
