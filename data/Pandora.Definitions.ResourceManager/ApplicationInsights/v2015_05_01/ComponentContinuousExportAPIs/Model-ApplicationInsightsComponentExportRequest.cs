using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentContinuousExportAPIs;


internal class ApplicationInsightsComponentExportRequestModel
{
    [JsonPropertyName("DestinationAccountId")]
    public string? DestinationAccountId { get; set; }

    [JsonPropertyName("DestinationAddress")]
    public string? DestinationAddress { get; set; }

    [JsonPropertyName("DestinationStorageLocationId")]
    public string? DestinationStorageLocationId { get; set; }

    [JsonPropertyName("DestinationStorageSubscriptionId")]
    public string? DestinationStorageSubscriptionId { get; set; }

    [JsonPropertyName("DestinationType")]
    public string? DestinationType { get; set; }

    [JsonPropertyName("IsEnabled")]
    public string? IsEnabled { get; set; }

    [JsonPropertyName("NotificationQueueEnabled")]
    public string? NotificationQueueEnabled { get; set; }

    [JsonPropertyName("NotificationQueueUri")]
    public string? NotificationQueueUri { get; set; }

    [JsonPropertyName("RecordTypes")]
    public string? RecordTypes { get; set; }
}
