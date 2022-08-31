using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2022_01_01_preview.DisasterRecoveryConfigs;


internal class ArmDisasterRecoveryPropertiesModel
{
    [JsonPropertyName("alternateName")]
    public string? AlternateName { get; set; }

    [JsonPropertyName("partnerNamespace")]
    public string? PartnerNamespace { get; set; }

    [JsonPropertyName("pendingReplicationOperationsCount")]
    public int? PendingReplicationOperationsCount { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateDRConstant? ProvisioningState { get; set; }

    [JsonPropertyName("role")]
    public RoleDisasterRecoveryConstant? Role { get; set; }
}
