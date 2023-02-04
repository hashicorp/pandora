using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.HyperVSites;


internal class SiteHealthSummaryModel
{
    [JsonPropertyName("affectedObjectsCount")]
    public int? AffectedObjectsCount { get; set; }

    [JsonPropertyName("affectedResourceType")]
    public string? AffectedResourceType { get; set; }

    [JsonPropertyName("affectedResources")]
    public List<string>? AffectedResources { get; set; }

    [JsonPropertyName("applianceName")]
    public string? ApplianceName { get; set; }

    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("errorId")]
    public int? ErrorId { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("hitCount")]
    public int? HitCount { get; set; }

    [JsonPropertyName("remediationGuidance")]
    public string? RemediationGuidance { get; set; }

    [JsonPropertyName("severity")]
    public string? Severity { get; set; }

    [JsonPropertyName("summaryMessage")]
    public string? SummaryMessage { get; set; }
}
