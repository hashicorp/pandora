using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentContinuousExportAPIs;


internal class ApplicationInsightsComponentExportConfigurationModel
{
    [JsonPropertyName("ApplicationName")]
    public string? ApplicationName { get; set; }

    [JsonPropertyName("ContainerName")]
    public string? ContainerName { get; set; }

    [JsonPropertyName("DestinationAccountId")]
    public string? DestinationAccountId { get; set; }

    [JsonPropertyName("DestinationStorageLocationId")]
    public string? DestinationStorageLocationId { get; set; }

    [JsonPropertyName("DestinationStorageSubscriptionId")]
    public string? DestinationStorageSubscriptionId { get; set; }

    [JsonPropertyName("DestinationType")]
    public string? DestinationType { get; set; }

    [JsonPropertyName("ExportId")]
    public string? ExportId { get; set; }

    [JsonPropertyName("ExportStatus")]
    public string? ExportStatus { get; set; }

    [JsonPropertyName("InstrumentationKey")]
    public string? InstrumentationKey { get; set; }

    [JsonPropertyName("IsUserEnabled")]
    public string? IsUserEnabled { get; set; }

    [JsonPropertyName("LastGapTime")]
    public string? LastGapTime { get; set; }

    [JsonPropertyName("LastSuccessTime")]
    public string? LastSuccessTime { get; set; }

    [JsonPropertyName("LastUserUpdate")]
    public string? LastUserUpdate { get; set; }

    [JsonPropertyName("NotificationQueueEnabled")]
    public string? NotificationQueueEnabled { get; set; }

    [JsonPropertyName("PermanentErrorReason")]
    public string? PermanentErrorReason { get; set; }

    [JsonPropertyName("RecordTypes")]
    public string? RecordTypes { get; set; }

    [JsonPropertyName("ResourceGroup")]
    public string? ResourceGroup { get; set; }

    [JsonPropertyName("StorageName")]
    public string? StorageName { get; set; }

    [JsonPropertyName("SubscriptionId")]
    public string? SubscriptionId { get; set; }
}
