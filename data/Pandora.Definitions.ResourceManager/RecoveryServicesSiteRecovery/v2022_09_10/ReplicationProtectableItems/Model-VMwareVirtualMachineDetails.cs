using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectableItems;

[ValueForType("VMwareVirtualMachine")]
internal class VMwareVirtualMachineDetailsModel : ConfigurationSettingsModel
{
    [JsonPropertyName("agentGeneratedId")]
    public string? AgentGeneratedId { get; set; }

    [JsonPropertyName("agentInstalled")]
    public string? AgentInstalled { get; set; }

    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [JsonPropertyName("discoveryType")]
    public string? DiscoveryType { get; set; }

    [JsonPropertyName("diskDetails")]
    public List<InMageDiskDetailsModel>? DiskDetails { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("poweredOn")]
    public string? PoweredOn { get; set; }

    [JsonPropertyName("vCenterInfrastructureId")]
    public string? VCenterInfrastructureId { get; set; }

    [JsonPropertyName("validationErrors")]
    public List<HealthErrorModel>? ValidationErrors { get; set; }
}
