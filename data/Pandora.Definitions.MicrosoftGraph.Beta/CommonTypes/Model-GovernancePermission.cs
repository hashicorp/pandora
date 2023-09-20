// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class GovernancePermissionModel
{
    [JsonPropertyName("accessLevel")]
    public string? AccessLevel { get; set; }

    [JsonPropertyName("isActive")]
    public bool? IsActive { get; set; }

    [JsonPropertyName("isEligible")]
    public bool? IsEligible { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
