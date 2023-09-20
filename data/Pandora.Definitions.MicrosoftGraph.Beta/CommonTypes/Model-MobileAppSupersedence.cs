// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MobileAppSupersedenceModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("supersededAppCount")]
    public int? SupersededAppCount { get; set; }

    [JsonPropertyName("supersedenceType")]
    public MobileAppSupersedenceSupersedenceTypeConstant? SupersedenceType { get; set; }

    [JsonPropertyName("supersedingAppCount")]
    public int? SupersedingAppCount { get; set; }

    [JsonPropertyName("targetDisplayName")]
    public string? TargetDisplayName { get; set; }

    [JsonPropertyName("targetDisplayVersion")]
    public string? TargetDisplayVersion { get; set; }

    [JsonPropertyName("targetId")]
    public string? TargetId { get; set; }

    [JsonPropertyName("targetPublisher")]
    public string? TargetPublisher { get; set; }

    [JsonPropertyName("targetType")]
    public MobileAppSupersedenceTargetTypeConstant? TargetType { get; set; }
}
