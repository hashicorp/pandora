using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Entities;

[ValueForType("SecurityAlert")]
internal class SecurityAlertTimelineItemModel : EntityTimelineItemModel
{
    [JsonPropertyName("alertType")]
    [Required]
    public string AlertType { get; set; }

    [JsonPropertyName("azureResourceId")]
    [Required]
    public string AzureResourceId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTimeUtc")]
    [Required]
    public DateTime EndTimeUtc { get; set; }

    [JsonPropertyName("intent")]
    public KillChainIntentConstant? Intent { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("severity")]
    [Required]
    public AlertSeverityConstant Severity { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTimeUtc")]
    [Required]
    public DateTime StartTimeUtc { get; set; }

    [JsonPropertyName("techniques")]
    public List<string>? Techniques { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeGenerated")]
    [Required]
    public DateTime TimeGenerated { get; set; }
}
