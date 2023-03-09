using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_11_01.Spacecraft;


internal class SpacecraftsPropertiesModel
{
    [JsonPropertyName("links")]
    [Required]
    public List<SpacecraftLinkModel> Links { get; set; }

    [JsonPropertyName("noradId")]
    public string? NoradId { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("titleLine")]
    [Required]
    public string TitleLine { get; set; }

    [JsonPropertyName("tleLine1")]
    [Required]
    public string TleLine1 { get; set; }

    [JsonPropertyName("tleLine2")]
    [Required]
    public string TleLine2 { get; set; }
}
