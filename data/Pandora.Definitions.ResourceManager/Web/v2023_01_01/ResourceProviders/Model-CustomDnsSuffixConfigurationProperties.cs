using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.ResourceProviders;


internal class CustomDnsSuffixConfigurationPropertiesModel
{
    [JsonPropertyName("certificateUrl")]
    public string? CertificateUrl { get; set; }

    [JsonPropertyName("dnsSuffix")]
    public string? DnsSuffix { get; set; }

    [JsonPropertyName("keyVaultReferenceIdentity")]
    public string? KeyVaultReferenceIdentity { get; set; }

    [JsonPropertyName("provisioningDetails")]
    public string? ProvisioningDetails { get; set; }

    [JsonPropertyName("provisioningState")]
    public CustomDnsSuffixProvisioningStateConstant? ProvisioningState { get; set; }
}
