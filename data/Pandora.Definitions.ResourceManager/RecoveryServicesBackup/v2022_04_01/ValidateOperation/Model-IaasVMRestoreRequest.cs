using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.ValidateOperation;

[ValueForType("IaasVMRestoreRequest")]
internal class IaasVMRestoreRequestModel : RestoreRequestModel
{
    [JsonPropertyName("affinityGroup")]
    public string? AffinityGroup { get; set; }

    [JsonPropertyName("createNewCloudService")]
    public bool? CreateNewCloudService { get; set; }

    [JsonPropertyName("diskEncryptionSetId")]
    public string? DiskEncryptionSetId { get; set; }

    [JsonPropertyName("encryptionDetails")]
    public EncryptionDetailsModel? EncryptionDetails { get; set; }

    [JsonPropertyName("identityBasedRestoreDetails")]
    public IdentityBasedRestoreDetailsModel? IdentityBasedRestoreDetails { get; set; }

    [JsonPropertyName("identityInfo")]
    public IdentityInfoModel? IdentityInfo { get; set; }

    [JsonPropertyName("originalStorageAccountOption")]
    public bool? OriginalStorageAccountOption { get; set; }

    [JsonPropertyName("recoveryPointId")]
    public string? RecoveryPointId { get; set; }

    [JsonPropertyName("recoveryType")]
    public RecoveryTypeConstant? RecoveryType { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("restoreDiskLunList")]
    public List<int>? RestoreDiskLunList { get; set; }

    [JsonPropertyName("restoreWithManagedDisks")]
    public bool? RestoreWithManagedDisks { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }

    [JsonPropertyName("targetDomainNameId")]
    public string? TargetDomainNameId { get; set; }

    [JsonPropertyName("targetResourceGroupId")]
    public string? TargetResourceGroupId { get; set; }

    [JsonPropertyName("targetVirtualMachineId")]
    public string? TargetVirtualMachineId { get; set; }

    [JsonPropertyName("virtualNetworkId")]
    public string? VirtualNetworkId { get; set; }

    [JsonPropertyName("zones")]
    public CustomTypes.Zones? Zones { get; set; }
}
