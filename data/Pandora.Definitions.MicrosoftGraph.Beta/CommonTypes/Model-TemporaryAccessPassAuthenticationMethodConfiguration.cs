// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TemporaryAccessPassAuthenticationMethodConfigurationModel
{
    [JsonPropertyName("defaultLength")]
    public int? DefaultLength { get; set; }

    [JsonPropertyName("defaultLifetimeInMinutes")]
    public int? DefaultLifetimeInMinutes { get; set; }

    [JsonPropertyName("excludeTargets")]
    public List<ExcludeTargetModel>? ExcludeTargets { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("includeTargets")]
    public List<AuthenticationMethodTargetModel>? IncludeTargets { get; set; }

    [JsonPropertyName("isUsableOnce")]
    public bool? IsUsableOnce { get; set; }

    [JsonPropertyName("maximumLifetimeInMinutes")]
    public int? MaximumLifetimeInMinutes { get; set; }

    [JsonPropertyName("minimumLifetimeInMinutes")]
    public int? MinimumLifetimeInMinutes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public TemporaryAccessPassAuthenticationMethodConfigurationStateConstant? State { get; set; }
}
