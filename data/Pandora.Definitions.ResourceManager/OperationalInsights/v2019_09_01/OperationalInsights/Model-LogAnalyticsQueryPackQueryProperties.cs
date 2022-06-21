using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2019_09_01.OperationalInsights;


internal class LogAnalyticsQueryPackQueryPropertiesModel
{
    [JsonPropertyName("author")]
    public string? Author { get; set; }

    [JsonPropertyName("body")]
    [Required]
    public string Body { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("properties")]
    public object? Properties { get; set; }

    [JsonPropertyName("related")]
    public LogAnalyticsQueryPackQueryPropertiesRelatedModel? Related { get; set; }

    [JsonPropertyName("tags")]
    public Dictionary<string, List<string>>? Tags { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeCreated")]
    public DateTime? TimeCreated { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeModified")]
    public DateTime? TimeModified { get; set; }
}
