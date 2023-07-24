using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Recommendations;


internal class RecommendationPropertiesModel
{
    [JsonPropertyName("actionName")]
    public string? ActionName { get; set; }

    [JsonPropertyName("bladeName")]
    public string? BladeName { get; set; }

    [JsonPropertyName("categoryTags")]
    public List<string>? CategoryTags { get; set; }

    [JsonPropertyName("channels")]
    public ChannelsConstant? Channels { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enabled")]
    public int? Enabled { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("extensionName")]
    public string? ExtensionName { get; set; }

    [JsonPropertyName("forwardLink")]
    public string? ForwardLink { get; set; }

    [JsonPropertyName("isDynamic")]
    public bool? IsDynamic { get; set; }

    [JsonPropertyName("level")]
    public NotificationLevelConstant? Level { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("nextNotificationTime")]
    public DateTime? NextNotificationTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("notificationExpirationTime")]
    public DateTime? NotificationExpirationTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("notifiedTime")]
    public DateTime? NotifiedTime { get; set; }

    [JsonPropertyName("recommendationId")]
    public string? RecommendationId { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("resourceScope")]
    public ResourceScopeTypeConstant? ResourceScope { get; set; }

    [JsonPropertyName("ruleName")]
    public string? RuleName { get; set; }

    [JsonPropertyName("score")]
    public float? Score { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("states")]
    public List<string>? States { get; set; }
}
