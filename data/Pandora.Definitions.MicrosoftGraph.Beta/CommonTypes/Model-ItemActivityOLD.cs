// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ItemActivityOLDModel
{
    [JsonPropertyName("action")]
    public ItemActionSetModel? Action { get; set; }

    [JsonPropertyName("actor")]
    public IdentitySetModel? Actor { get; set; }

    [JsonPropertyName("driveItem")]
    public DriveItemModel? DriveItem { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("listItem")]
    public ListItemModel? ListItem { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("times")]
    public ItemActivityTimeSetModel? Times { get; set; }
}
