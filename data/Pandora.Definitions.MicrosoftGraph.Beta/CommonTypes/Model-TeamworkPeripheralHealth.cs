// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkPeripheralHealthModel
{
    [JsonPropertyName("connection")]
    public TeamworkConnectionModel? Connection { get; set; }

    [JsonPropertyName("isOptional")]
    public bool? IsOptional { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("peripheral")]
    public TeamworkPeripheralModel? Peripheral { get; set; }
}
