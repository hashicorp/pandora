using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_12_01.AppPlatform;


internal abstract class CertificatePropertiesModel
{
    [JsonPropertyName("activateDate")]
    public string? ActivateDate { get; set; }

    [JsonPropertyName("dnsNames")]
    public List<string>? DnsNames { get; set; }

    [JsonPropertyName("expirationDate")]
    public string? ExpirationDate { get; set; }

    [JsonPropertyName("issuedDate")]
    public string? IssuedDate { get; set; }

    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    [JsonPropertyName("provisioningState")]
    public CertificateResourceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("subjectName")]
    public string? SubjectName { get; set; }

    [JsonPropertyName("thumbprint")]
    public string? Thumbprint { get; set; }

    [JsonPropertyName("type")]
    [ProvidesTypeHint]
    [Required]
    public string Type { get; set; }
}
