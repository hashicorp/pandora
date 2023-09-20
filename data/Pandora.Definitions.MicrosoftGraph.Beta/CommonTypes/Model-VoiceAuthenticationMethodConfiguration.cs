// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VoiceAuthenticationMethodConfigurationModel
{
    [JsonPropertyName("excludeTargets")]
    public List<ExcludeTargetModel>? ExcludeTargets { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("includeTargets")]
    public List<VoiceAuthenticationMethodTargetModel>? IncludeTargets { get; set; }

    [JsonPropertyName("isOfficePhoneAllowed")]
    public bool? IsOfficePhoneAllowed { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public VoiceAuthenticationMethodConfigurationStateConstant? State { get; set; }
}
