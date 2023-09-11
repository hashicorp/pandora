using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Certificate;


internal class CertificateContractPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationDate")]
    [Required]
    public DateTime ExpirationDate { get; set; }

    [JsonPropertyName("keyVault")]
    public KeyVaultContractPropertiesModel? KeyVault { get; set; }

    [JsonPropertyName("subject")]
    [Required]
    public string Subject { get; set; }

    [JsonPropertyName("thumbprint")]
    [Required]
    public string Thumbprint { get; set; }
}
