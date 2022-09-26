using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.LogAnalytics;


internal class LogAnalyticsInputBaseModel
{
    [JsonPropertyName("blobContainerSasUri")]
    [Required]
    public string BlobContainerSasUri { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("fromTime")]
    [Required]
    public DateTime FromTime { get; set; }

    [JsonPropertyName("groupByClientApplicationId")]
    public bool? GroupByClientApplicationId { get; set; }

    [JsonPropertyName("groupByOperationName")]
    public bool? GroupByOperationName { get; set; }

    [JsonPropertyName("groupByResourceName")]
    public bool? GroupByResourceName { get; set; }

    [JsonPropertyName("groupByThrottlePolicy")]
    public bool? GroupByThrottlePolicy { get; set; }

    [JsonPropertyName("groupByUserAgent")]
    public bool? GroupByUserAgent { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("toTime")]
    [Required]
    public DateTime ToTime { get; set; }
}
