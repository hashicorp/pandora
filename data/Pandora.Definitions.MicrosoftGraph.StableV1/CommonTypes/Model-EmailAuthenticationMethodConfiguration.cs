// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class EmailAuthenticationMethodConfigurationModel
{
    [JsonPropertyName("allowExternalIdToUseEmailOtp")]
    public ExternalEmailOtpStateConstant? AllowExternalIdToUseEmailOtp { get; set; }

    [JsonPropertyName("excludeTargets")]
    public List<ExcludeTargetModel>? ExcludeTargets { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("includeTargets")]
    public List<AuthenticationMethodTargetModel>? IncludeTargets { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public AuthenticationMethodStateConstant? State { get; set; }
}
