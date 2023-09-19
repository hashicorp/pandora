// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CustomSecurityAttributeAuditModel
{
    [JsonPropertyName("activityDateTime")]
    public DateTime? ActivityDateTime { get; set; }

    [JsonPropertyName("activityDisplayName")]
    public string? ActivityDisplayName { get; set; }

    [JsonPropertyName("additionalDetails")]
    public List<KeyValueModel>? AdditionalDetails { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("initiatedBy")]
    public AuditActivityInitiatorModel? InitiatedBy { get; set; }

    [JsonPropertyName("loggedByService")]
    public string? LoggedByService { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operationType")]
    public string? OperationType { get; set; }

    [JsonPropertyName("result")]
    public CustomSecurityAttributeAuditResultConstant? Result { get; set; }

    [JsonPropertyName("resultReason")]
    public string? ResultReason { get; set; }

    [JsonPropertyName("targetResources")]
    public List<TargetResourceModel>? TargetResources { get; set; }

    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }
}
