// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class X509CertificateAuthenticationModeConfigurationModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rules")]
    public List<X509CertificateRuleModel>? Rules { get; set; }

    [JsonPropertyName("x509CertificateAuthenticationDefaultMode")]
    public X509CertificateAuthenticationModeConstant? X509CertificateAuthenticationDefaultMode { get; set; }
}
