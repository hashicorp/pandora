using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.ReplicationvCenters;


internal class VCenterPropertiesModel
{
    [JsonPropertyName("discoveryStatus")]
    public string? DiscoveryStatus { get; set; }

    [JsonPropertyName("fabricArmResourceName")]
    public string? FabricArmResourceName { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("healthErrors")]
    public List<HealthErrorModel>? HealthErrors { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("infrastructureId")]
    public string? InfrastructureId { get; set; }

    [JsonPropertyName("internalId")]
    public string? InternalId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartbeat")]
    public DateTime? LastHeartbeat { get; set; }

    [JsonPropertyName("port")]
    public string? Port { get; set; }

    [JsonPropertyName("processServerId")]
    public string? ProcessServerId { get; set; }

    [JsonPropertyName("runAsAccountId")]
    public string? RunAsAccountId { get; set; }
}
