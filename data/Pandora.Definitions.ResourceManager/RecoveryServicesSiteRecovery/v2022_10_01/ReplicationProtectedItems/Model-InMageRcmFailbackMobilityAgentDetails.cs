using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;


internal class InMageRcmFailbackMobilityAgentDetailsModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("agentVersionExpiryDate")]
    public DateTime? AgentVersionExpiryDate { get; set; }

    [JsonPropertyName("driverVersion")]
    public string? DriverVersion { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("driverVersionExpiryDate")]
    public DateTime? DriverVersionExpiryDate { get; set; }

    [JsonPropertyName("isUpgradeable")]
    public string? IsUpgradeable { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartbeatUtc")]
    public DateTime? LastHeartbeatUtc { get; set; }

    [JsonPropertyName("latestUpgradableVersionWithoutReboot")]
    public string? LatestUpgradableVersionWithoutReboot { get; set; }

    [JsonPropertyName("latestVersion")]
    public string? LatestVersion { get; set; }

    [JsonPropertyName("reasonsBlockingUpgrade")]
    public List<AgentUpgradeBlockedReasonConstant>? ReasonsBlockingUpgrade { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
