// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SecurityRetentionEventModel
{
    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("eventPropagationResults")]
    public List<EventPropagationResultModel>? EventPropagationResults { get; set; }

    [JsonPropertyName("eventQueries")]
    public List<EventQueryModel>? EventQueries { get; set; }

    [JsonPropertyName("eventStatus")]
    public RetentionEventStatusModel? EventStatus { get; set; }

    [JsonPropertyName("eventTriggerDateTime")]
    public DateTime? EventTriggerDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("lastStatusUpdateDateTime")]
    public DateTime? LastStatusUpdateDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("retentionEventType")]
    public RetentionEventTypeModel? RetentionEventType { get; set; }
}
