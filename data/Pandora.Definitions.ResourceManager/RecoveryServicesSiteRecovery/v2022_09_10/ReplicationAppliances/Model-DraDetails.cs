using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationAppliances;


internal class DraDetailsModel
{
    [JsonPropertyName("biosId")]
    public string? BiosId { get; set; }

    [JsonPropertyName("forwardProtectedItemCount")]
    public int? ForwardProtectedItemCount { get; set; }

    [JsonPropertyName("health")]
    public ProtectionHealthConstant? Health { get; set; }

    [JsonPropertyName("healthErrors")]
    public List<HealthErrorModel>? HealthErrors { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartbeatUtc")]
    public DateTime? LastHeartbeatUtc { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("reverseProtectedItemCount")]
    public int? ReverseProtectedItemCount { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
