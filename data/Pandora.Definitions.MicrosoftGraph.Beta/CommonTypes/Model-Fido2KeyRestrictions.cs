// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Fido2KeyRestrictionsModel
{
    [JsonPropertyName("aaGuids")]
    public List<string>? AaGuids { get; set; }

    [JsonPropertyName("enforcementType")]
    public Fido2KeyRestrictionsEnforcementTypeConstant? EnforcementType { get; set; }

    [JsonPropertyName("isEnforced")]
    public bool? IsEnforced { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
