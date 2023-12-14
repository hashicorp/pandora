// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class X509CertificateUserBindingModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("trustAffinityLevel")]
    public X509CertificateUserBindingTrustAffinityLevelConstant? TrustAffinityLevel { get; set; }

    [JsonPropertyName("userProperty")]
    public string? UserProperty { get; set; }

    [JsonPropertyName("x509CertificateField")]
    public string? X509CertificateField { get; set; }
}
