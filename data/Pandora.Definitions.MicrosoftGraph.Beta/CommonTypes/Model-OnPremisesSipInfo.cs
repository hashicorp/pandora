// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OnPremisesSipInfoModel
{
    [JsonPropertyName("isSipEnabled")]
    public bool? IsSipEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sipDeploymentLocation")]
    public string? SipDeploymentLocation { get; set; }

    [JsonPropertyName("sipPrimaryAddress")]
    public string? SipPrimaryAddress { get; set; }
}
