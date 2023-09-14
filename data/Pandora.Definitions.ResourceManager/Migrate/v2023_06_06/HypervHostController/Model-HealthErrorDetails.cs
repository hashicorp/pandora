using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.HypervHostController;


internal class HealthErrorDetailsModel
{
    [JsonPropertyName("applianceName")]
    public string? ApplianceName { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("discoveryScope")]
    public HealthErrorDetailsDiscoveryScopeConstant? DiscoveryScope { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("messageParameters")]
    public Dictionary<string, string>? MessageParameters { get; set; }

    [JsonPropertyName("possibleCauses")]
    public string? PossibleCauses { get; set; }

    [JsonPropertyName("recommendedAction")]
    public string? RecommendedAction { get; set; }

    [JsonPropertyName("runAsAccountId")]
    public string? RunAsAccountId { get; set; }

    [JsonPropertyName("severity")]
    public string? Severity { get; set; }

    [JsonPropertyName("source")]
    public HealthErrorDetailsSourceConstant? Source { get; set; }

    [JsonPropertyName("summaryMessage")]
    public string? SummaryMessage { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updatedTimeStamp")]
    public DateTime? UpdatedTimeStamp { get; set; }
}
