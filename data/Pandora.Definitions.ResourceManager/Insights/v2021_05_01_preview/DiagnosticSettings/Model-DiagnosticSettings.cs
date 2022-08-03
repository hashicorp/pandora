using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.DiagnosticSettings;


internal class DiagnosticSettingsModel
{
    [JsonPropertyName("eventHubAuthorizationRuleId")]
    public string? EventHubAuthorizationRuleId { get; set; }

    [JsonPropertyName("eventHubName")]
    public string? EventHubName { get; set; }

    [JsonPropertyName("logAnalyticsDestinationType")]
    public string? LogAnalyticsDestinationType { get; set; }

    [JsonPropertyName("logs")]
    public List<LogSettingsModel>? Logs { get; set; }

    [JsonPropertyName("marketplacePartnerId")]
    public string? MarketplacePartnerId { get; set; }

    [JsonPropertyName("metrics")]
    public List<MetricSettingsModel>? Metrics { get; set; }

    [JsonPropertyName("serviceBusRuleId")]
    public string? ServiceBusRuleId { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }

    [JsonPropertyName("workspaceId")]
    public string? WorkspaceId { get; set; }
}
