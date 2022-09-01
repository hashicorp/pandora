using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors;


internal class HealthProbeSettingsPropertiesModel
{
    [JsonPropertyName("enabledState")]
    public HealthProbeEnabledConstant? EnabledState { get; set; }

    [JsonPropertyName("healthProbeMethod")]
    public FrontDoorHealthProbeMethodConstant? HealthProbeMethod { get; set; }

    [JsonPropertyName("intervalInSeconds")]
    public int? IntervalInSeconds { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("protocol")]
    public FrontDoorProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("resourceState")]
    public FrontDoorResourceStateConstant? ResourceState { get; set; }
}
