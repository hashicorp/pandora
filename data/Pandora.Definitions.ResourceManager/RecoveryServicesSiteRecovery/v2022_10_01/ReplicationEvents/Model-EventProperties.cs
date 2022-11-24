using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationEvents;


internal class EventPropertiesModel
{
    [JsonPropertyName("affectedObjectCorrelationId")]
    public string? AffectedObjectCorrelationId { get; set; }

    [JsonPropertyName("affectedObjectFriendlyName")]
    public string? AffectedObjectFriendlyName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("eventCode")]
    public string? EventCode { get; set; }

    [JsonPropertyName("eventSpecificDetails")]
    public EventSpecificDetailsModel? EventSpecificDetails { get; set; }

    [JsonPropertyName("eventType")]
    public string? EventType { get; set; }

    [JsonPropertyName("fabricId")]
    public string? FabricId { get; set; }

    [JsonPropertyName("healthErrors")]
    public List<HealthErrorModel>? HealthErrors { get; set; }

    [JsonPropertyName("providerSpecificDetails")]
    public EventProviderSpecificDetailsModel? ProviderSpecificDetails { get; set; }

    [JsonPropertyName("severity")]
    public string? Severity { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeOfOccurrence")]
    public DateTime? TimeOfOccurrence { get; set; }
}
