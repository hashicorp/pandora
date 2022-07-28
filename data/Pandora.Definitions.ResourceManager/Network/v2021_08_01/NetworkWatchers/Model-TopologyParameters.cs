using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkWatchers;


internal class TopologyParametersModel
{
    [JsonPropertyName("targetResourceGroupName")]
    public string? TargetResourceGroupName { get; set; }

    [JsonPropertyName("targetSubnet")]
    public SubResourceModel? TargetSubnet { get; set; }

    [JsonPropertyName("targetVirtualNetwork")]
    public SubResourceModel? TargetVirtualNetwork { get; set; }
}
