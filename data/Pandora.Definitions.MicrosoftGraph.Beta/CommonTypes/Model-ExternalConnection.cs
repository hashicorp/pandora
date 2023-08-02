// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ExternalConnectionModel
{
    [JsonPropertyName("configuration")]
    public ConfigurationModel? Configuration { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("groups")]
    public List<ExternalGroupModel>? Groups { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("items")]
    public List<ExternalItemModel>? Items { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<ConnectionOperationModel>? Operations { get; set; }

    [JsonPropertyName("schema")]
    public SchemaModel? Schema { get; set; }

    [JsonPropertyName("state")]
    public ConnectionStateConstant? State { get; set; }
}
