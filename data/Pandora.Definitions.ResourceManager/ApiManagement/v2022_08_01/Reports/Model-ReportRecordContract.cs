using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Reports;


internal class ReportRecordContractModel
{
    [JsonPropertyName("apiId")]
    public string? ApiId { get; set; }

    [JsonPropertyName("apiRegion")]
    public string? ApiRegion { get; set; }

    [JsonPropertyName("apiTimeAvg")]
    public float? ApiTimeAvg { get; set; }

    [JsonPropertyName("apiTimeMax")]
    public float? ApiTimeMax { get; set; }

    [JsonPropertyName("apiTimeMin")]
    public float? ApiTimeMin { get; set; }

    [JsonPropertyName("bandwidth")]
    public int? Bandwidth { get; set; }

    [JsonPropertyName("cacheHitCount")]
    public int? CacheHitCount { get; set; }

    [JsonPropertyName("cacheMissCount")]
    public int? CacheMissCount { get; set; }

    [JsonPropertyName("callCountBlocked")]
    public int? CallCountBlocked { get; set; }

    [JsonPropertyName("callCountFailed")]
    public int? CallCountFailed { get; set; }

    [JsonPropertyName("callCountOther")]
    public int? CallCountOther { get; set; }

    [JsonPropertyName("callCountSuccess")]
    public int? CallCountSuccess { get; set; }

    [JsonPropertyName("callCountTotal")]
    public int? CallCountTotal { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("interval")]
    public string? Interval { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("operationId")]
    public string? OperationId { get; set; }

    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("serviceTimeAvg")]
    public float? ServiceTimeAvg { get; set; }

    [JsonPropertyName("serviceTimeMax")]
    public float? ServiceTimeMax { get; set; }

    [JsonPropertyName("serviceTimeMin")]
    public float? ServiceTimeMin { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("zip")]
    public string? Zip { get; set; }
}
