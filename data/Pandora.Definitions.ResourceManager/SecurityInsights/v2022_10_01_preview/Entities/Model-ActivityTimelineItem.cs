using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Entities;

[ValueForType("Activity")]
internal class ActivityTimelineItemModel : EntityTimelineItemModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("bucketEndTimeUTC")]
    [Required]
    public DateTime BucketEndTimeUTC { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("bucketStartTimeUTC")]
    [Required]
    public DateTime BucketStartTimeUTC { get; set; }

    [JsonPropertyName("content")]
    [Required]
    public string Content { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("firstActivityTimeUTC")]
    [Required]
    public DateTime FirstActivityTimeUTC { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastActivityTimeUTC")]
    [Required]
    public DateTime LastActivityTimeUTC { get; set; }

    [JsonPropertyName("queryId")]
    [Required]
    public string QueryId { get; set; }

    [JsonPropertyName("title")]
    [Required]
    public string Title { get; set; }
}
