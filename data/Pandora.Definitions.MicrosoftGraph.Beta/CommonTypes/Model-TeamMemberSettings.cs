// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamMemberSettingsModel
{
    [JsonPropertyName("allowAddRemoveApps")]
    public bool? AllowAddRemoveApps { get; set; }

    [JsonPropertyName("allowCreatePrivateChannels")]
    public bool? AllowCreatePrivateChannels { get; set; }

    [JsonPropertyName("allowCreateUpdateChannels")]
    public bool? AllowCreateUpdateChannels { get; set; }

    [JsonPropertyName("allowCreateUpdateRemoveConnectors")]
    public bool? AllowCreateUpdateRemoveConnectors { get; set; }

    [JsonPropertyName("allowCreateUpdateRemoveTabs")]
    public bool? AllowCreateUpdateRemoveTabs { get; set; }

    [JsonPropertyName("allowDeleteChannels")]
    public bool? AllowDeleteChannels { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
