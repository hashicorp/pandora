using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApiManagementService;


internal class HostnameConfigurationModel
{
    [JsonPropertyName("certificate")]
    public CertificateInformationModel? Certificate { get; set; }

    [JsonPropertyName("certificatePassword")]
    public string? CertificatePassword { get; set; }

    [JsonPropertyName("certificateSource")]
    public CertificateSourceConstant? CertificateSource { get; set; }

    [JsonPropertyName("certificateStatus")]
    public CertificateStatusConstant? CertificateStatus { get; set; }

    [JsonPropertyName("defaultSslBinding")]
    public bool? DefaultSslBinding { get; set; }

    [JsonPropertyName("encodedCertificate")]
    public string? EncodedCertificate { get; set; }

    [JsonPropertyName("hostName")]
    [Required]
    public string HostName { get; set; }

    [JsonPropertyName("identityClientId")]
    public string? IdentityClientId { get; set; }

    [JsonPropertyName("keyVaultId")]
    public string? KeyVaultId { get; set; }

    [JsonPropertyName("negotiateClientCertificate")]
    public bool? NegotiateClientCertificate { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public HostnameTypeConstant Type { get; set; }
}
