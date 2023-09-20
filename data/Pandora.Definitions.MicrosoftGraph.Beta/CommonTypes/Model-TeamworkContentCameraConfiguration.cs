// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkContentCameraConfigurationModel
{
    [JsonPropertyName("isContentCameraInverted")]
    public bool? IsContentCameraInverted { get; set; }

    [JsonPropertyName("isContentCameraOptional")]
    public bool? IsContentCameraOptional { get; set; }

    [JsonPropertyName("isContentEnhancementEnabled")]
    public bool? IsContentEnhancementEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
