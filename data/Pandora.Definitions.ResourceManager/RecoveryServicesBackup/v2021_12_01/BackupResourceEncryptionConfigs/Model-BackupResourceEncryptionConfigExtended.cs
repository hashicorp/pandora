using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupResourceEncryptionConfigs;


internal class BackupResourceEncryptionConfigExtendedModel
{
    [JsonPropertyName("encryptionAtRestType")]
    public EncryptionAtRestTypeConstant? EncryptionAtRestType { get; set; }

    [JsonPropertyName("infrastructureEncryptionState")]
    public InfrastructureEncryptionStateConstant? InfrastructureEncryptionState { get; set; }

    [JsonPropertyName("keyUri")]
    public string? KeyUri { get; set; }

    [JsonPropertyName("lastUpdateStatus")]
    public LastUpdateStatusConstant? LastUpdateStatus { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("useSystemAssignedIdentity")]
    public bool? UseSystemAssignedIdentity { get; set; }

    [JsonPropertyName("userAssignedIdentity")]
    public string? UserAssignedIdentity { get; set; }
}
