using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;


internal class RulesEngineActionModel
{
    [JsonPropertyName("requestHeaderActions")]
    public List<HeaderActionModel>? RequestHeaderActions { get; set; }

    [JsonPropertyName("responseHeaderActions")]
    public List<HeaderActionModel>? ResponseHeaderActions { get; set; }

    [JsonPropertyName("routeConfigurationOverride")]
    public RouteConfigurationModel? RouteConfigurationOverride { get; set; }
}
