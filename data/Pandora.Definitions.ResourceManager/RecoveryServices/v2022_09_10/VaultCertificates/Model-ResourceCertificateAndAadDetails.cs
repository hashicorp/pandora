using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2022_09_10.VaultCertificates;

[ValueForType("AzureActiveDirectory")]
internal class ResourceCertificateAndAadDetailsModel : ResourceCertificateDetailsModel
{
    [JsonPropertyName("aadAudience")]
    public string? AadAudience { get; set; }

    [JsonPropertyName("aadAuthority")]
    [Required]
    public string AadAuthority { get; set; }

    [JsonPropertyName("aadTenantId")]
    [Required]
    public string AadTenantId { get; set; }

    [JsonPropertyName("azureManagementEndpointAudience")]
    [Required]
    public string AzureManagementEndpointAudience { get; set; }

    [JsonPropertyName("servicePrincipalClientId")]
    [Required]
    public string ServicePrincipalClientId { get; set; }

    [JsonPropertyName("servicePrincipalObjectId")]
    [Required]
    public string ServicePrincipalObjectId { get; set; }

    [JsonPropertyName("serviceResourceId")]
    public string? ServiceResourceId { get; set; }
}
