// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AuditEventModel
{
    [JsonPropertyName("activity")]
    public string? Activity { get; set; }

    [JsonPropertyName("activityDateTime")]
    public DateTime? ActivityDateTime { get; set; }

    [JsonPropertyName("activityId")]
    public string? ActivityId { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("httpVerb")]
    public string? HttpVerb { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("initiatedByAppId")]
    public string? InitiatedByAppId { get; set; }

    [JsonPropertyName("initiatedByUpn")]
    public string? InitiatedByUpn { get; set; }

    [JsonPropertyName("initiatedByUserId")]
    public string? InitiatedByUserId { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("requestBody")]
    public string? RequestBody { get; set; }

    [JsonPropertyName("requestUrl")]
    public string? RequestUrl { get; set; }

    [JsonPropertyName("tenantIds")]
    public string? TenantIds { get; set; }

    [JsonPropertyName("tenantNames")]
    public string? TenantNames { get; set; }
}
