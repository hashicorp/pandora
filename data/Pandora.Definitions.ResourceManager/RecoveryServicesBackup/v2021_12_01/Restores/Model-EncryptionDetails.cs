using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.Restores;


internal class EncryptionDetailsModel
{
    [JsonPropertyName("encryptionEnabled")]
    public bool? EncryptionEnabled { get; set; }

    [JsonPropertyName("kekUrl")]
    public string? KekUrl { get; set; }

    [JsonPropertyName("kekVaultId")]
    public string? KekVaultId { get; set; }

    [JsonPropertyName("secretKeyUrl")]
    public string? SecretKeyUrl { get; set; }

    [JsonPropertyName("secretKeyVaultId")]
    public string? SecretKeyVaultId { get; set; }
}
