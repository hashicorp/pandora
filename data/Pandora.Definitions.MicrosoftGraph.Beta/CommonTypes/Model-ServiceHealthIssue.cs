// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ServiceHealthIssueModel
{
    [JsonPropertyName("classification")]
    public ServiceHealthIssueClassificationConstant? Classification { get; set; }

    [JsonPropertyName("details")]
    public List<KeyValuePairModel>? Details { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("feature")]
    public string? Feature { get; set; }

    [JsonPropertyName("featureGroup")]
    public string? FeatureGroup { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("impactDescription")]
    public string? ImpactDescription { get; set; }

    [JsonPropertyName("isResolved")]
    public bool? IsResolved { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("origin")]
    public ServiceHealthIssueOriginConstant? Origin { get; set; }

    [JsonPropertyName("posts")]
    public List<ServiceHealthIssuePostModel>? Posts { get; set; }

    [JsonPropertyName("service")]
    public string? Service { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("status")]
    public ServiceHealthIssueStatusConstant? Status { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
