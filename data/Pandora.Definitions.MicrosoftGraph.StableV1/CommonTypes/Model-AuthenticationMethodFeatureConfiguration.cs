// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AuthenticationMethodFeatureConfigurationModel
{
    [JsonPropertyName("excludeTarget")]
    public FeatureTargetModel? ExcludeTarget { get; set; }

    [JsonPropertyName("includeTarget")]
    public FeatureTargetModel? IncludeTarget { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public AuthenticationMethodFeatureConfigurationStateConstant? State { get; set; }
}
