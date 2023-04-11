using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.AlertsSuppressionRules;


internal class AlertsSuppressionRulePropertiesModel
{
    [JsonPropertyName("alertType")]
    [Required]
    public string AlertType { get; set; }

    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationDateUtc")]
    public DateTime? ExpirationDateUtc { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedUtc")]
    public DateTime? LastModifiedUtc { get; set; }

    [JsonPropertyName("reason")]
    [Required]
    public string Reason { get; set; }

    [JsonPropertyName("state")]
    [Required]
    public RuleStateConstant State { get; set; }

    [JsonPropertyName("suppressionAlertsScope")]
    public SuppressionAlertsScopeModel? SuppressionAlertsScope { get; set; }
}
