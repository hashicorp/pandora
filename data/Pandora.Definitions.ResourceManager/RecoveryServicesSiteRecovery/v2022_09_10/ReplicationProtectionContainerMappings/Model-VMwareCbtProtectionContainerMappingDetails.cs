using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectionContainerMappings;

[ValueForType("VMwareCbt")]
internal class VMwareCbtProtectionContainerMappingDetailsModel : ProtectionContainerMappingProviderSpecificDetailsModel
{
    [JsonPropertyName("keyVaultId")]
    public string? KeyVaultId { get; set; }

    [JsonPropertyName("keyVaultUri")]
    public string? KeyVaultUri { get; set; }

    [JsonPropertyName("roleSizeToNicCountMap")]
    public Dictionary<string, int>? RoleSizeToNicCountMap { get; set; }

    [JsonPropertyName("serviceBusConnectionStringSecretName")]
    public string? ServiceBusConnectionStringSecretName { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }

    [JsonPropertyName("storageAccountSasSecretName")]
    public string? StorageAccountSasSecretName { get; set; }

    [JsonPropertyName("targetLocation")]
    public string? TargetLocation { get; set; }
}
