using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.Spacecraft;


internal class SpacecraftsPropertiesModel
{
    [JsonPropertyName("links")]
    public List<SpacecraftLinkModel>? Links { get; set; }

    [JsonPropertyName("noradId")]
    [Required]
    public string NoradId { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("titleLine")]
    public string? TitleLine { get; set; }

    [JsonPropertyName("tleLine1")]
    public string? TleLineOne { get; set; }

    [JsonPropertyName("tleLine2")]
    public string? TleLineTwo { get; set; }
}
