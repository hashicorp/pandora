// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SynchronizationSchemaModel
{
    [JsonPropertyName("directories")]
    public List<DirectoryDefinitionModel>? Directories { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("synchronizationRules")]
    public List<SynchronizationRuleModel>? SynchronizationRules { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
