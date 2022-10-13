using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectableItems;

[ValueForType("HyperVVirtualMachine")]
internal class HyperVVirtualMachineDetailsModel : ConfigurationSettingsModel
{
    [JsonPropertyName("diskDetails")]
    public List<DiskDetailsModel>? DiskDetails { get; set; }

    [JsonPropertyName("generation")]
    public string? Generation { get; set; }

    [JsonPropertyName("hasFibreChannelAdapter")]
    public PresenceStatusConstant? HasFibreChannelAdapter { get; set; }

    [JsonPropertyName("hasPhysicalDisk")]
    public PresenceStatusConstant? HasPhysicalDisk { get; set; }

    [JsonPropertyName("hasSharedVhd")]
    public PresenceStatusConstant? HasSharedVhd { get; set; }

    [JsonPropertyName("hyperVHostId")]
    public string? HyperVHostId { get; set; }

    [JsonPropertyName("osDetails")]
    public OSDetailsModel? OsDetails { get; set; }

    [JsonPropertyName("sourceItemId")]
    public string? SourceItemId { get; set; }
}
