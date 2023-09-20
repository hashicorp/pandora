// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SecurityUnifiedGroupSourceModel
{
    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("group")]
    public GroupModel? Group { get; set; }

    [JsonPropertyName("holdStatus")]
    public SecurityUnifiedGroupSourceHoldStatusConstant? HoldStatus { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("includedSources")]
    public SecurityUnifiedGroupSourceIncludedSourcesConstant? IncludedSources { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
