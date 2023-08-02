// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Fido2CombinationConfigurationModel
{
    [JsonPropertyName("allowedAAGUIDs")]
    public List<string>? AllowedAAGUIDs { get; set; }

    [JsonPropertyName("appliesToCombinations")]
    public List<AuthenticationMethodModesConstant>? AppliesToCombinations { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
