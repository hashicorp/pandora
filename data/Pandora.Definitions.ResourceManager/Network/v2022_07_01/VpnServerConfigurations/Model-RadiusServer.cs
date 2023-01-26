using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VpnServerConfigurations;


internal class RadiusServerModel
{
    [JsonPropertyName("radiusServerAddress")]
    [Required]
    public string RadiusServerAddress { get; set; }

    [JsonPropertyName("radiusServerScore")]
    public int? RadiusServerScore { get; set; }

    [JsonPropertyName("radiusServerSecret")]
    public string? RadiusServerSecret { get; set; }
}
