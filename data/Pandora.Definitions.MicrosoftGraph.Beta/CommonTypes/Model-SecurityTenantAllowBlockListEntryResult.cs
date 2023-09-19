// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityTenantAllowBlockListEntryResultModel
{
    [JsonPropertyName("entryType")]
    public SecurityTenantAllowBlockListEntryResultEntryTypeConstant? EntryType { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("identity")]
    public string? Identity { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public SecurityTenantAllowBlockListEntryResultStatusConstant? Status { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
