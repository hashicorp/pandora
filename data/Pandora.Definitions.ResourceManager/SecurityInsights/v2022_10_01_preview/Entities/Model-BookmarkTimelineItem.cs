using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Entities;

[ValueForType("Bookmark")]
internal class BookmarkTimelineItemModel : EntityTimelineItemModel
{
    [JsonPropertyName("azureResourceId")]
    [Required]
    public string AzureResourceId { get; set; }

    [JsonPropertyName("createdBy")]
    public UserInfoModel? CreatedBy { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTimeUtc")]
    public DateTime? EndTimeUtc { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("eventTime")]
    public DateTime? EventTime { get; set; }

    [JsonPropertyName("labels")]
    public List<string>? Labels { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTimeUtc")]
    public DateTime? StartTimeUtc { get; set; }
}
