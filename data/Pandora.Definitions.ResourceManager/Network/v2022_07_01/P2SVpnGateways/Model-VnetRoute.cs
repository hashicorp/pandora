using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.P2SVpnGateways;


internal class VnetRouteModel
{
    [JsonPropertyName("bgpConnections")]
    public List<SubResourceModel>? BgpConnections { get; set; }

    [JsonPropertyName("staticRoutes")]
    public List<StaticRouteModel>? StaticRoutes { get; set; }

    [JsonPropertyName("staticRoutesConfig")]
    public StaticRoutesConfigModel? StaticRoutesConfig { get; set; }
}
