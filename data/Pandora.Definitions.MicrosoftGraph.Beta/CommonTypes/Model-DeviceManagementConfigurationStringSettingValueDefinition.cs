// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementConfigurationStringSettingValueDefinitionModel
{
    [JsonPropertyName("fileTypes")]
    public List<string>? FileTypes { get; set; }

    [JsonPropertyName("format")]
    public DeviceManagementConfigurationStringSettingValueDefinitionFormatConstant? Format { get; set; }

    [JsonPropertyName("inputValidationSchema")]
    public string? InputValidationSchema { get; set; }

    [JsonPropertyName("isSecret")]
    public bool? IsSecret { get; set; }

    [JsonPropertyName("maximumLength")]
    public int? MaximumLength { get; set; }

    [JsonPropertyName("minimumLength")]
    public int? MinimumLength { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
