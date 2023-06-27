using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.AttachedDataNetworks;


internal class NaptConfigurationModel
{
    [JsonPropertyName("enabled")]
    public NaptEnabledConstant? Enabled { get; set; }

    [JsonPropertyName("pinholeLimits")]
    public int? PinholeLimits { get; set; }

    [JsonPropertyName("pinholeTimeouts")]
    public PinholeTimeoutsModel? PinholeTimeouts { get; set; }

    [JsonPropertyName("portRange")]
    public PortRangeModel? PortRange { get; set; }

    [JsonPropertyName("portReuseHoldTime")]
    public PortReuseHoldTimesModel? PortReuseHoldTime { get; set; }
}
