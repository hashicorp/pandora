// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkDisplayConfigurationModel
{
    [JsonPropertyName("configuredDisplays")]
    public List<TeamworkConfiguredPeripheralModel>? ConfiguredDisplays { get; set; }

    [JsonPropertyName("displayCount")]
    public int? DisplayCount { get; set; }

    [JsonPropertyName("inBuiltDisplayScreenConfiguration")]
    public TeamworkDisplayScreenConfigurationModel? InBuiltDisplayScreenConfiguration { get; set; }

    [JsonPropertyName("isContentDuplicationAllowed")]
    public bool? IsContentDuplicationAllowed { get; set; }

    [JsonPropertyName("isDualDisplayModeEnabled")]
    public bool? IsDualDisplayModeEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
