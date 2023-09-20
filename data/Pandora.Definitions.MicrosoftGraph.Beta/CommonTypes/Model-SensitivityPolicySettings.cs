// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SensitivityPolicySettingsModel
{
    [JsonPropertyName("applicableTo")]
    public SensitivityPolicySettingsApplicableToConstant? ApplicableTo { get; set; }

    [JsonPropertyName("downgradeSensitivityRequiresJustification")]
    public bool? DowngradeSensitivityRequiresJustification { get; set; }

    [JsonPropertyName("helpWebUrl")]
    public string? HelpWebUrl { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isMandatory")]
    public bool? IsMandatory { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
