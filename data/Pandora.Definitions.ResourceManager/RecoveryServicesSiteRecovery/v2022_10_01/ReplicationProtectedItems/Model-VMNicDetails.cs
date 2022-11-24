using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;


internal class VMNicDetailsModel
{
    [JsonPropertyName("enableAcceleratedNetworkingOnRecovery")]
    public bool? EnableAcceleratedNetworkingOnRecovery { get; set; }

    [JsonPropertyName("enableAcceleratedNetworkingOnTfo")]
    public bool? EnableAcceleratedNetworkingOnTfo { get; set; }

    [JsonPropertyName("ipConfigs")]
    public List<IPConfigDetailsModel>? IPConfigs { get; set; }

    [JsonPropertyName("nicId")]
    public string? NicId { get; set; }

    [JsonPropertyName("recoveryNetworkSecurityGroupId")]
    public string? RecoveryNetworkSecurityGroupId { get; set; }

    [JsonPropertyName("recoveryNicName")]
    public string? RecoveryNicName { get; set; }

    [JsonPropertyName("recoveryNicResourceGroupName")]
    public string? RecoveryNicResourceGroupName { get; set; }

    [JsonPropertyName("recoveryVMNetworkId")]
    public string? RecoveryVMNetworkId { get; set; }

    [JsonPropertyName("replicaNicId")]
    public string? ReplicaNicId { get; set; }

    [JsonPropertyName("reuseExistingNic")]
    public bool? ReuseExistingNic { get; set; }

    [JsonPropertyName("selectionType")]
    public string? SelectionType { get; set; }

    [JsonPropertyName("sourceNicArmId")]
    public string? SourceNicArmId { get; set; }

    [JsonPropertyName("targetNicName")]
    public string? TargetNicName { get; set; }

    [JsonPropertyName("tfoNetworkSecurityGroupId")]
    public string? TfoNetworkSecurityGroupId { get; set; }

    [JsonPropertyName("tfoRecoveryNicName")]
    public string? TfoRecoveryNicName { get; set; }

    [JsonPropertyName("tfoRecoveryNicResourceGroupName")]
    public string? TfoRecoveryNicResourceGroupName { get; set; }

    [JsonPropertyName("tfoReuseExistingNic")]
    public bool? TfoReuseExistingNic { get; set; }

    [JsonPropertyName("tfoVMNetworkId")]
    public string? TfoVMNetworkId { get; set; }

    [JsonPropertyName("vMNetworkName")]
    public string? VMNetworkName { get; set; }
}
