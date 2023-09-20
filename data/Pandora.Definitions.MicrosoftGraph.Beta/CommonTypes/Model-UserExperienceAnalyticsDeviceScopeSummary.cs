// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsDeviceScopeSummaryModel
{
    [JsonPropertyName("completedDeviceScopeIds")]
    public List<string>? CompletedDeviceScopeIds { get; set; }

    [JsonPropertyName("insufficientDataDeviceScopeIds")]
    public List<string>? InsufficientDataDeviceScopeIds { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("totalDeviceScopes")]
    public int? TotalDeviceScopes { get; set; }

    [JsonPropertyName("totalDeviceScopesEnabled")]
    public int? TotalDeviceScopesEnabled { get; set; }
}
