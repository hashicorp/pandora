// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class LogonUserModel
{
    [JsonPropertyName("accountDomain")]
    public string? AccountDomain { get; set; }

    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("accountType")]
    public UserAccountSecurityTypeConstant? AccountType { get; set; }

    [JsonPropertyName("firstSeenDateTime")]
    public DateTime? FirstSeenDateTime { get; set; }

    [JsonPropertyName("lastSeenDateTime")]
    public DateTime? LastSeenDateTime { get; set; }

    [JsonPropertyName("logonId")]
    public string? LogonId { get; set; }

    [JsonPropertyName("logonTypes")]
    public List<LogonTypeConstant>? LogonTypes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
