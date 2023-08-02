// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class DirectoryDefinitionModel
{
    [JsonPropertyName("discoverabilities")]
    public DirectoryDefinitionDiscoverabilitiesConstant? Discoverabilities { get; set; }

    [JsonPropertyName("discoveryDateTime")]
    public DateTime? DiscoveryDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("objects")]
    public List<ObjectDefinitionModel>? Objects { get; set; }

    [JsonPropertyName("readOnly")]
    public bool? ReadOnly { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
