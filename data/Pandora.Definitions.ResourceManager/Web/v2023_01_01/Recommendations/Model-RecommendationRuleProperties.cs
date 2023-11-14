using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Recommendations;


internal class RecommendationRulePropertiesModel
{
    [JsonPropertyName("actionName")]
    public string? ActionName { get; set; }

    [JsonPropertyName("bladeName")]
    public string? BladeName { get; set; }

    [JsonPropertyName("categoryTags")]
    public List<string>? CategoryTags { get; set; }

    [JsonPropertyName("channels")]
    public ChannelsConstant? Channels { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

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

    [JsonPropertyName("recommendationId")]
    public string? RecommendationId { get; set; }

    [JsonPropertyName("recommendationName")]
    public string? RecommendationName { get; set; }
}
