// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SettingModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("jsonValue")]
    public string? JsonValue { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("overwriteAllowed")]
    public bool? OverwriteAllowed { get; set; }

    [JsonPropertyName("settingId")]
    public string? SettingId { get; set; }

    [JsonPropertyName("valueType")]
    public ManagementParameterValueTypeConstant? ValueType { get; set; }
}
