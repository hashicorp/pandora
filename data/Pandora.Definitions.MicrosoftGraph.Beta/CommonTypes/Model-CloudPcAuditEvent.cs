// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPcAuditEventModel
{
    [JsonPropertyName("activity")]
    public string? Activity { get; set; }

    [JsonPropertyName("activityDateTime")]
    public DateTime? ActivityDateTime { get; set; }

    [JsonPropertyName("activityOperationType")]
    public CloudPcAuditActivityOperationTypeConstant? ActivityOperationType { get; set; }

    [JsonPropertyName("activityResult")]
    public CloudPcAuditActivityResultConstant? ActivityResult { get; set; }

    [JsonPropertyName("activityType")]
    public string? ActivityType { get; set; }

    [JsonPropertyName("actor")]
    public CloudPcAuditActorModel? Actor { get; set; }

    [JsonPropertyName("category")]
    public CloudPcAuditCategoryConstant? Category { get; set; }

    [JsonPropertyName("componentName")]
    public string? ComponentName { get; set; }

    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resources")]
    public List<CloudPcAuditResourceModel>? Resources { get; set; }
}
