// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CredentialUsageSummaryModel
{
    [JsonPropertyName("authMethod")]
    public UsageAuthMethodConstant? AuthMethod { get; set; }

    [JsonPropertyName("failureActivityCount")]
    public long? FailureActivityCount { get; set; }

    [JsonPropertyName("feature")]
    public FeatureTypeConstant? Feature { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("successfulActivityCount")]
    public long? SuccessfulActivityCount { get; set; }
}
