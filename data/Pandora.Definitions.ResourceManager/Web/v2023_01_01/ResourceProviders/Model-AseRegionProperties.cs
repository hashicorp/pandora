using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.ResourceProviders;


internal class AseRegionPropertiesModel
{
    [JsonPropertyName("availableOS")]
    public List<string>? AvailableOS { get; set; }

    [JsonPropertyName("availableSku")]
    public List<string>? AvailableSku { get; set; }

    [JsonPropertyName("dedicatedHost")]
    public bool? DedicatedHost { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("standard")]
    public bool? Standard { get; set; }

    [JsonPropertyName("zoneRedundant")]
    public bool? ZoneRedundant { get; set; }
}
