// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementSettingComparisonModel
{
    [JsonPropertyName("comparisonResult")]
    public DeviceManagementSettingComparisonComparisonResultConstant? ComparisonResult { get; set; }

    [JsonPropertyName("currentValueJson")]
    public string? CurrentValueJson { get; set; }

    [JsonPropertyName("definitionId")]
    public string? DefinitionId { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("newValueJson")]
    public string? NewValueJson { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
