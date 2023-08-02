// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsManagedTenantExecutionErrorModel
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("errorDetails")]
    public string? ErrorDetails { get; set; }

    [JsonPropertyName("nodeId")]
    public int? NodeId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rawToken")]
    public string? RawToken { get; set; }

    [JsonPropertyName("statementIndex")]
    public int? StatementIndex { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
