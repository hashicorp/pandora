using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2015_04_01.ActivityLogs;


internal class EventDataModel
{
    [JsonPropertyName("authorization")]
    public SenderAuthorizationModel? Authorization { get; set; }

    [JsonPropertyName("caller")]
    public string? Caller { get; set; }

    [JsonPropertyName("category")]
    public LocalizableStringModel? Category { get; set; }

    [JsonPropertyName("claims")]
    public Dictionary<string, string>? Claims { get; set; }

    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("eventDataId")]
    public string? EventDataId { get; set; }

    [JsonPropertyName("eventName")]
    public LocalizableStringModel? EventName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("eventTimestamp")]
    public DateTime? EventTimestamp { get; set; }

    [JsonPropertyName("httpRequest")]
    public HTTPRequestInfoModel? HTTPRequest { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("level")]
    public EventLevelConstant? Level { get; set; }

    [JsonPropertyName("operationId")]
    public string? OperationId { get; set; }

    [JsonPropertyName("operationName")]
    public LocalizableStringModel? OperationName { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("resourceGroupName")]
    public string? ResourceGroupName { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("resourceProviderName")]
    public LocalizableStringModel? ResourceProviderName { get; set; }

    [JsonPropertyName("resourceType")]
    public LocalizableStringModel? ResourceType { get; set; }

    [JsonPropertyName("status")]
    public LocalizableStringModel? Status { get; set; }

    [JsonPropertyName("subStatus")]
    public LocalizableStringModel? SubStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("submissionTimestamp")]
    public DateTime? SubmissionTimestamp { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
