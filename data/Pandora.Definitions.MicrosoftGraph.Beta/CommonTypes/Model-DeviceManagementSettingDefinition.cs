// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementSettingDefinitionModel
{
    [JsonPropertyName("constraints")]
    public List<DeviceManagementConstraintModel>? Constraints { get; set; }

    [JsonPropertyName("dependencies")]
    public List<DeviceManagementSettingDependencyModel>? Dependencies { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("documentationUrl")]
    public string? DocumentationUrl { get; set; }

    [JsonPropertyName("headerSubtitle")]
    public string? HeaderSubtitle { get; set; }

    [JsonPropertyName("headerTitle")]
    public string? HeaderTitle { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isTopLevel")]
    public bool? IsTopLevel { get; set; }

    [JsonPropertyName("keywords")]
    public List<string>? Keywords { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("placeholderText")]
    public string? PlaceholderText { get; set; }

    [JsonPropertyName("valueType")]
    public DeviceManagementSettingDefinitionValueTypeConstant? ValueType { get; set; }
}
