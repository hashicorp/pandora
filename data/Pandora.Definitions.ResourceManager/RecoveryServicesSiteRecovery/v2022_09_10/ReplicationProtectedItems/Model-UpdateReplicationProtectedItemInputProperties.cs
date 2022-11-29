using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectedItems;


internal class UpdateReplicationProtectedItemInputPropertiesModel
{
    [JsonPropertyName("enableRdpOnTargetOption")]
    public string? EnableRdpOnTargetOption { get; set; }

    [JsonPropertyName("licenseType")]
    public LicenseTypeConstant? LicenseType { get; set; }

    [JsonPropertyName("providerSpecificDetails")]
    public UpdateReplicationProtectedItemProviderInputModel? ProviderSpecificDetails { get; set; }

    [JsonPropertyName("recoveryAvailabilitySetId")]
    public string? RecoveryAvailabilitySetId { get; set; }

    [JsonPropertyName("recoveryAzureVMName")]
    public string? RecoveryAzureVMName { get; set; }

    [JsonPropertyName("recoveryAzureVMSize")]
    public string? RecoveryAzureVMSize { get; set; }

    [JsonPropertyName("selectedRecoveryAzureNetworkId")]
    public string? SelectedRecoveryAzureNetworkId { get; set; }

    [JsonPropertyName("selectedSourceNicId")]
    public string? SelectedSourceNicId { get; set; }

    [JsonPropertyName("selectedTfoAzureNetworkId")]
    public string? SelectedTfoAzureNetworkId { get; set; }

    [JsonPropertyName("vmNics")]
    public List<VMNicInputDetailsModel>? VMNics { get; set; }
}
