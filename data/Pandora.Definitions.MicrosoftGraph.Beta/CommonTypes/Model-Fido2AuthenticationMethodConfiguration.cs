// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Fido2AuthenticationMethodConfigurationModel
{
    [JsonPropertyName("excludeTargets")]
    public List<ExcludeTargetModel>? ExcludeTargets { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAttestationEnforced")]
    public bool? IsAttestationEnforced { get; set; }

    [JsonPropertyName("isSelfServiceRegistrationAllowed")]
    public bool? IsSelfServiceRegistrationAllowed { get; set; }

    [JsonPropertyName("keyRestrictions")]
    public Fido2KeyRestrictionsModel? KeyRestrictions { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public Fido2AuthenticationMethodConfigurationStateConstant? State { get; set; }
}
