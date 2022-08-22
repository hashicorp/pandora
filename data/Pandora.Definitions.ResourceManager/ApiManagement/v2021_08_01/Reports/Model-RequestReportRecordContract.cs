using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Reports;


internal class RequestReportRecordContractModel
{
    [JsonPropertyName("apiId")]
    public string? ApiId { get; set; }

    [JsonPropertyName("apiRegion")]
    public string? ApiRegion { get; set; }

    [JsonPropertyName("apiTime")]
    public float? ApiTime { get; set; }

    [JsonPropertyName("backendResponseCode")]
    public string? BackendResponseCode { get; set; }

    [JsonPropertyName("cache")]
    public string? Cache { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("method")]
    public string? Method { get; set; }

    [JsonPropertyName("operationId")]
    public string? OperationId { get; set; }

    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonPropertyName("requestSize")]
    public int? RequestSize { get; set; }

    [JsonPropertyName("responseCode")]
    public int? ResponseCode { get; set; }

    [JsonPropertyName("responseSize")]
    public int? ResponseSize { get; set; }

    [JsonPropertyName("serviceTime")]
    public float? ServiceTime { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}
