// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ConditionalAccessPolicyModel
{
    [JsonPropertyName("conditions")]
    public ConditionalAccessConditionSetModel? Conditions { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("grantControls")]
    public ConditionalAccessGrantControlsModel? GrantControls { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("modifiedDateTime")]
    public DateTime? ModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sessionControls")]
    public ConditionalAccessSessionControlsModel? SessionControls { get; set; }

    [JsonPropertyName("state")]
    public ConditionalAccessPolicyStateConstant? State { get; set; }

    [JsonPropertyName("templateId")]
    public string? TemplateId { get; set; }
}
