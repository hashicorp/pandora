// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IosEduCertificateSettingsModel
{
    [JsonPropertyName("certFileName")]
    public string? CertFileName { get; set; }

    [JsonPropertyName("certificateTemplateName")]
    public string? CertificateTemplateName { get; set; }

    [JsonPropertyName("certificateValidityPeriodScale")]
    public CertificateValidityPeriodScaleConstant? CertificateValidityPeriodScale { get; set; }

    [JsonPropertyName("certificateValidityPeriodValue")]
    public int? CertificateValidityPeriodValue { get; set; }

    [JsonPropertyName("certificationAuthority")]
    public string? CertificationAuthority { get; set; }

    [JsonPropertyName("certificationAuthorityName")]
    public string? CertificationAuthorityName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("renewalThresholdPercentage")]
    public int? RenewalThresholdPercentage { get; set; }

    [JsonPropertyName("trustedRootCertificate")]
    public string? TrustedRootCertificate { get; set; }
}
