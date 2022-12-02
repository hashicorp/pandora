using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupStatus;


internal class BackupStatusResponseModel
{
    [JsonPropertyName("containerName")]
    public string? ContainerName { get; set; }

    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("fabricName")]
    public FabricNameConstant? FabricName { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }

    [JsonPropertyName("protectedItemName")]
    public string? ProtectedItemName { get; set; }

    [JsonPropertyName("protectionStatus")]
    public ProtectionStatusConstant? ProtectionStatus { get; set; }

    [JsonPropertyName("registrationStatus")]
    public string? RegistrationStatus { get; set; }

    [JsonPropertyName("vaultId")]
    public string? VaultId { get; set; }
}
