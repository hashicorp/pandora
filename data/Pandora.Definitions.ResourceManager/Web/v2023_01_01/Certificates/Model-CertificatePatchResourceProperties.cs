using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Certificates;


internal class CertificatePatchResourcePropertiesModel
{
    [JsonPropertyName("canonicalName")]
    public string? CanonicalName { get; set; }

    [JsonPropertyName("cerBlob")]
    public string? CerBlob { get; set; }

    [JsonPropertyName("domainValidationMethod")]
    public string? DomainValidationMethod { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("hostNames")]
    public List<string>? HostNames { get; set; }

    [JsonPropertyName("hostingEnvironmentProfile")]
    public HostingEnvironmentProfileModel? HostingEnvironmentProfile { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("issueDate")]
    public DateTime? IssueDate { get; set; }

    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    [JsonPropertyName("keyVaultId")]
    public string? KeyVaultId { get; set; }

    [JsonPropertyName("keyVaultSecretName")]
    public string? KeyVaultSecretName { get; set; }

    [JsonPropertyName("keyVaultSecretStatus")]
    public KeyVaultSecretStatusConstant? KeyVaultSecretStatus { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("pfxBlob")]
    public string? PfxBlob { get; set; }

    [JsonPropertyName("publicKeyHash")]
    public string? PublicKeyHash { get; set; }

    [JsonPropertyName("selfLink")]
    public string? SelfLink { get; set; }

    [JsonPropertyName("serverFarmId")]
    public string? ServerFarmId { get; set; }

    [JsonPropertyName("siteName")]
    public string? SiteName { get; set; }

    [JsonPropertyName("subjectName")]
    public string? SubjectName { get; set; }

    [JsonPropertyName("thumbprint")]
    public string? Thumbprint { get; set; }

    [JsonPropertyName("valid")]
    public bool? Valid { get; set; }
}
