// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrivilegedRoleSummaryModel
{
    [JsonPropertyName("elevatedCount")]
    public int? ElevatedCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managedCount")]
    public int? ManagedCount { get; set; }

    [JsonPropertyName("mfaEnabled")]
    public bool? MfaEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public PrivilegedRoleSummaryStatusConstant? Status { get; set; }

    [JsonPropertyName("usersCount")]
    public int? UsersCount { get; set; }
}
