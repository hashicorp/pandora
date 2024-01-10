// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Windows10XSCEPCertificateProfileModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceManagementResourceAccessProfileAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("certificateStore")]
    public Windows10XSCEPCertificateProfileCertificateStoreConstant? CertificateStore { get; set; }

    [JsonPropertyName("certificateValidityPeriodScale")]
    public Windows10XSCEPCertificateProfileCertificateValidityPeriodScaleConstant? CertificateValidityPeriodScale { get; set; }

    [JsonPropertyName("certificateValidityPeriodValue")]
    public int? CertificateValidityPeriodValue { get; set; }

    [JsonPropertyName("creationDateTime")]
    public DateTime? CreationDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("extendedKeyUsages")]
    public List<ExtendedKeyUsageModel>? ExtendedKeyUsages { get; set; }

    [JsonPropertyName("hashAlgorithm")]
    public List<Windows10XSCEPCertificateProfileHashAlgorithmConstant>? HashAlgorithm { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("keySize")]
    public Windows10XSCEPCertificateProfileKeySizeConstant? KeySize { get; set; }

    [JsonPropertyName("keyStorageProvider")]
    public Windows10XSCEPCertificateProfileKeyStorageProviderConstant? KeyStorageProvider { get; set; }

    [JsonPropertyName("keyUsage")]
    public Windows10XSCEPCertificateProfileKeyUsageConstant? KeyUsage { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("renewalThresholdPercentage")]
    public int? RenewalThresholdPercentage { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("rootCertificateId")]
    public string? RootCertificateId { get; set; }

    [JsonPropertyName("scepServerUrls")]
    public List<string>? ScepServerUrls { get; set; }

    [JsonPropertyName("subjectAlternativeNameFormats")]
    public List<Windows10XCustomSubjectAlternativeNameModel>? SubjectAlternativeNameFormats { get; set; }

    [JsonPropertyName("subjectNameFormatString")]
    public string? SubjectNameFormatString { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
