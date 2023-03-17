using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.ReplicationAppliances;


internal class ReprotectAgentDetailsModel
{
    [JsonPropertyName("accessibleDatastores")]
    public List<string>? AccessibleDatastores { get; set; }

    [JsonPropertyName("biosId")]
    public string? BiosId { get; set; }

    [JsonPropertyName("fabricObjectId")]
    public string? FabricObjectId { get; set; }

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("health")]
    public ProtectionHealthConstant? Health { get; set; }

    [JsonPropertyName("healthErrors")]
    public List<HealthErrorModel>? HealthErrors { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastDiscoveryInUtc")]
    public DateTime? LastDiscoveryInUtc { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartbeatUtc")]
    public DateTime? LastHeartbeatUtc { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("protectedItemCount")]
    public int? ProtectedItemCount { get; set; }

    [JsonPropertyName("vcenterId")]
    public string? VcenterId { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
