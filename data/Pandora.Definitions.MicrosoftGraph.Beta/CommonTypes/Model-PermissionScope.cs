// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PermissionScopeModel
{
    [JsonPropertyName("adminConsentDescription")]
    public string? AdminConsentDescription { get; set; }

    [JsonPropertyName("adminConsentDisplayName")]
    public string? AdminConsentDisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("origin")]
    public string? Origin { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("userConsentDescription")]
    public string? UserConsentDescription { get; set; }

    [JsonPropertyName("userConsentDisplayName")]
    public string? UserConsentDisplayName { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
