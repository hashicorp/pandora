using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.IncidentAlerts;


internal class HuntingBookmarkPropertiesModel
{
    [JsonPropertyName("additionalData")]
    public object? AdditionalData { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("createdBy")]
    public UserInfoModel? CreatedBy { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("eventTime")]
    public DateTime? EventTime { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("incidentInfo")]
    public IncidentInfoModel? IncidentInfo { get; set; }

    [JsonPropertyName("labels")]
    public List<string>? Labels { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("query")]
    [Required]
    public string Query { get; set; }

    [JsonPropertyName("queryResult")]
    public string? QueryResult { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updated")]
    public DateTime? Updated { get; set; }

    [JsonPropertyName("updatedBy")]
    public UserInfoModel? UpdatedBy { get; set; }
}
