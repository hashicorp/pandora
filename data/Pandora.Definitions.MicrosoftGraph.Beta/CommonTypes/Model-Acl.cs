// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AclModel
{
    [JsonPropertyName("accessType")]
    public AclAccessTypeConstant? AccessType { get; set; }

    [JsonPropertyName("identitySource")]
    public AclIdentitySourceConstant? IdentitySource { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("type")]
    public AclTypeConstant? Type { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
