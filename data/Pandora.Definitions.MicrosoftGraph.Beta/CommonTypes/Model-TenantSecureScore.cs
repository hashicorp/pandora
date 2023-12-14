// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TenantSecureScoreModel
{
    [JsonPropertyName("createDateTime")]
    public DateTime? CreateDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tenantMaxScore")]
    public int? TenantMaxScore { get; set; }

    [JsonPropertyName("tenantScore")]
    public int? TenantScore { get; set; }
}
