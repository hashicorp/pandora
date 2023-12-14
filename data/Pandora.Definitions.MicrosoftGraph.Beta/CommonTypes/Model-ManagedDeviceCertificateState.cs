// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedDeviceCertificateStateModel
{
    [JsonPropertyName("certificateEnhancedKeyUsage")]
    public string? CertificateEnhancedKeyUsage { get; set; }

    [JsonPropertyName("certificateErrorCode")]
    public int? CertificateErrorCode { get; set; }

    [JsonPropertyName("certificateExpirationDateTime")]
    public DateTime? CertificateExpirationDateTime { get; set; }

    [JsonPropertyName("certificateIssuanceDateTime")]
    public DateTime? CertificateIssuanceDateTime { get; set; }

    [JsonPropertyName("certificateIssuanceState")]
    public ManagedDeviceCertificateStateCertificateIssuanceStateConstant? CertificateIssuanceState { get; set; }

    [JsonPropertyName("certificateIssuer")]
    public string? CertificateIssuer { get; set; }

    [JsonPropertyName("certificateKeyLength")]
    public int? CertificateKeyLength { get; set; }

    [JsonPropertyName("certificateKeyStorageProvider")]
    public ManagedDeviceCertificateStateCertificateKeyStorageProviderConstant? CertificateKeyStorageProvider { get; set; }

    [JsonPropertyName("certificateKeyUsage")]
    public ManagedDeviceCertificateStateCertificateKeyUsageConstant? CertificateKeyUsage { get; set; }

    [JsonPropertyName("certificateLastIssuanceStateChangedDateTime")]
    public DateTime? CertificateLastIssuanceStateChangedDateTime { get; set; }

    [JsonPropertyName("certificateProfileDisplayName")]
    public string? CertificateProfileDisplayName { get; set; }

    [JsonPropertyName("certificateRevokeStatus")]
    public ManagedDeviceCertificateStateCertificateRevokeStatusConstant? CertificateRevokeStatus { get; set; }

    [JsonPropertyName("certificateSerialNumber")]
    public string? CertificateSerialNumber { get; set; }

    [JsonPropertyName("certificateSubjectAlternativeNameFormat")]
    public ManagedDeviceCertificateStateCertificateSubjectAlternativeNameFormatConstant? CertificateSubjectAlternativeNameFormat { get; set; }

    [JsonPropertyName("certificateSubjectAlternativeNameFormatString")]
    public string? CertificateSubjectAlternativeNameFormatString { get; set; }

    [JsonPropertyName("certificateSubjectNameFormat")]
    public ManagedDeviceCertificateStateCertificateSubjectNameFormatConstant? CertificateSubjectNameFormat { get; set; }

    [JsonPropertyName("certificateSubjectNameFormatString")]
    public string? CertificateSubjectNameFormatString { get; set; }

    [JsonPropertyName("certificateThumbprint")]
    public string? CertificateThumbprint { get; set; }

    [JsonPropertyName("certificateValidityPeriod")]
    public int? CertificateValidityPeriod { get; set; }

    [JsonPropertyName("certificateValidityPeriodUnits")]
    public ManagedDeviceCertificateStateCertificateValidityPeriodUnitsConstant? CertificateValidityPeriodUnits { get; set; }

    [JsonPropertyName("deviceDisplayName")]
    public string? DeviceDisplayName { get; set; }

    [JsonPropertyName("devicePlatform")]
    public ManagedDeviceCertificateStateDevicePlatformConstant? DevicePlatform { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastCertificateStateChangeDateTime")]
    public DateTime? LastCertificateStateChangeDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }
}
