// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MicrosoftTunnelSiteModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("internalNetworkProbeUrl")]
    public string? InternalNetworkProbeUrl { get; set; }

    [JsonPropertyName("microsoftTunnelConfiguration")]
    public MicrosoftTunnelConfigurationModel? MicrosoftTunnelConfiguration { get; set; }

    [JsonPropertyName("microsoftTunnelServers")]
    public List<MicrosoftTunnelServerModel>? MicrosoftTunnelServers { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("publicAddress")]
    public string? PublicAddress { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("upgradeAutomatically")]
    public bool? UpgradeAutomatically { get; set; }

    [JsonPropertyName("upgradeAvailable")]
    public bool? UpgradeAvailable { get; set; }

    [JsonPropertyName("upgradeWindowEndTime")]
    public DateTime? UpgradeWindowEndTime { get; set; }

    [JsonPropertyName("upgradeWindowStartTime")]
    public DateTime? UpgradeWindowStartTime { get; set; }

    [JsonPropertyName("upgradeWindowUtcOffsetInMinutes")]
    public int? UpgradeWindowUtcOffsetInMinutes { get; set; }
}
