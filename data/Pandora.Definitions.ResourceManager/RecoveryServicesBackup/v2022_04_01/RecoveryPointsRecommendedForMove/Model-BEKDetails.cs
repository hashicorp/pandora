using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.RecoveryPointsRecommendedForMove;


internal class BEKDetailsModel
{
    [JsonPropertyName("secretData")]
    public string? SecretData { get; set; }

    [JsonPropertyName("secretUrl")]
    public string? SecretUrl { get; set; }

    [JsonPropertyName("secretVaultId")]
    public string? SecretVaultId { get; set; }
}
