using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.VirtualWANs;


internal class RoutingConfigurationModel
{
    [JsonPropertyName("associatedRouteTable")]
    public SubResourceModel? AssociatedRouteTable { get; set; }

    [JsonPropertyName("inboundRouteMap")]
    public SubResourceModel? InboundRouteMap { get; set; }

    [JsonPropertyName("outboundRouteMap")]
    public SubResourceModel? OutboundRouteMap { get; set; }

    [JsonPropertyName("propagatedRouteTables")]
    public PropagatedRouteTableModel? PropagatedRouteTables { get; set; }

    [JsonPropertyName("vnetRoutes")]
    public VnetRouteModel? VnetRoutes { get; set; }
}
