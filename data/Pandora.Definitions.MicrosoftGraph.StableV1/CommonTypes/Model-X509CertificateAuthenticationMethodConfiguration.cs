// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class X509CertificateAuthenticationMethodConfigurationModel
{
    [JsonPropertyName("authenticationModeConfiguration")]
    public X509CertificateAuthenticationModeConfigurationModel? AuthenticationModeConfiguration { get; set; }

    [JsonPropertyName("certificateUserBindings")]
    public List<X509CertificateUserBindingModel>? CertificateUserBindings { get; set; }

    [JsonPropertyName("excludeTargets")]
    public List<ExcludeTargetModel>? ExcludeTargets { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("includeTargets")]
    public List<AuthenticationMethodTargetModel>? IncludeTargets { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public AuthenticationMethodStateConstant? State { get; set; }
}
