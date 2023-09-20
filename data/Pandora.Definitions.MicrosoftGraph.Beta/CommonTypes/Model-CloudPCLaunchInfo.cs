// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPCLaunchInfoModel
{
    [JsonPropertyName("cloudPcId")]
    public string? CloudPCId { get; set; }

    [JsonPropertyName("cloudPcLaunchUrl")]
    public string? CloudPCLaunchUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("windows365SwitchCompatible")]
    public bool? Windows365SwitchCompatible { get; set; }

    [JsonPropertyName("windows365SwitchNotCompatibleReason")]
    public string? Windows365SwitchNotCompatibleReason { get; set; }
}
