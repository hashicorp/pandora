// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedAllDeviceCertificateStateModel
{
    [JsonPropertyName("certificateExpirationDateTime")]
    public DateTime? CertificateExpirationDateTime { get; set; }

    [JsonPropertyName("certificateExtendedKeyUsages")]
    public string? CertificateExtendedKeyUsages { get; set; }

    [JsonPropertyName("certificateIssuanceDateTime")]
    public DateTime? CertificateIssuanceDateTime { get; set; }

    [JsonPropertyName("certificateIssuerName")]
    public string? CertificateIssuerName { get; set; }

    [JsonPropertyName("certificateKeyUsages")]
    public int? CertificateKeyUsages { get; set; }

    [JsonPropertyName("certificateRevokeStatus")]
    public ManagedAllDeviceCertificateStateCertificateRevokeStatusConstant? CertificateRevokeStatus { get; set; }

    [JsonPropertyName("certificateRevokeStatusLastChangeDateTime")]
    public DateTime? CertificateRevokeStatusLastChangeDateTime { get; set; }

    [JsonPropertyName("certificateSerialNumber")]
    public string? CertificateSerialNumber { get; set; }

    [JsonPropertyName("certificateSubjectName")]
    public string? CertificateSubjectName { get; set; }

    [JsonPropertyName("certificateThumbprint")]
    public string? CertificateThumbprint { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managedDeviceDisplayName")]
    public string? ManagedDeviceDisplayName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
