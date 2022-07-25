using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2018_06_01.RecommendedActions;


internal class RecommendationActionPropertiesModel
{
    [JsonPropertyName("actionId")]
    public int? ActionId { get; set; }

    [JsonPropertyName("advisorName")]
    public string? AdvisorName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonPropertyName("details")]
    public Dictionary<string, string>? Details { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationTime")]
    public DateTime? ExpirationTime { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("recommendationType")]
    public string? RecommendationType { get; set; }

    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }
}
