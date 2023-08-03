// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AndroidManagedStoreAppConfigurationSchemaModel
{
    [JsonPropertyName("exampleJson")]
    public string? ExampleJson { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("nestedSchemaItems")]
    public List<AndroidManagedStoreAppConfigurationSchemaItemModel>? NestedSchemaItems { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("schemaItems")]
    public List<AndroidManagedStoreAppConfigurationSchemaItemModel>? SchemaItems { get; set; }
}
