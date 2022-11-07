using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_10_01.Deployments;


internal class ProviderResourceTypeModel
{
    [JsonPropertyName("aliases")]
    public List<AliasModel>? Aliases { get; set; }

    [JsonPropertyName("apiProfiles")]
    public List<ApiProfileModel>? ApiProfiles { get; set; }

    [JsonPropertyName("apiVersions")]
    public List<string>? ApiVersions { get; set; }

    [JsonPropertyName("capabilities")]
    public string? Capabilities { get; set; }

    [JsonPropertyName("defaultApiVersion")]
    public string? DefaultApiVersion { get; set; }

    [JsonPropertyName("locationMappings")]
    public List<ProviderExtendedLocationModel>? LocationMappings { get; set; }

    [JsonPropertyName("locations")]
    public List<string>? Locations { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("zoneMappings")]
    public List<ZoneMappingModel>? ZoneMappings { get; set; }
}
