// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPCAuditEventModel
{
    [JsonPropertyName("activity")]
    public string? Activity { get; set; }

    [JsonPropertyName("activityDateTime")]
    public DateTime? ActivityDateTime { get; set; }

    [JsonPropertyName("activityOperationType")]
    public CloudPCAuditEventActivityOperationTypeConstant? ActivityOperationType { get; set; }

    [JsonPropertyName("activityResult")]
    public CloudPCAuditEventActivityResultConstant? ActivityResult { get; set; }

    [JsonPropertyName("activityType")]
    public string? ActivityType { get; set; }

    [JsonPropertyName("actor")]
    public CloudPCAuditActorModel? Actor { get; set; }

    [JsonPropertyName("category")]
    public CloudPCAuditEventCategoryConstant? Category { get; set; }

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
    public List<CloudPCAuditResourceModel>? Resources { get; set; }
}
