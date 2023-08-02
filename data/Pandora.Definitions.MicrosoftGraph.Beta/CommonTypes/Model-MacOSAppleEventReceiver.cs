// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MacOSAppleEventReceiverModel
{
    [JsonPropertyName("allowed")]
    public bool? Allowed { get; set; }

    [JsonPropertyName("codeRequirement")]
    public string? CodeRequirement { get; set; }

    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    [JsonPropertyName("identifierType")]
    public MacOSProcessIdentifierTypeConstant? IdentifierType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
