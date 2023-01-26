using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteGateways;


internal class ExpressRouteGatewayPropertiesModel
{
    [JsonPropertyName("allowNonVirtualWanTraffic")]
    public bool? AllowNonVirtualWanTraffic { get; set; }

    [JsonPropertyName("autoScaleConfiguration")]
    public ExpressRouteGatewayPropertiesAutoScaleConfigurationModel? AutoScaleConfiguration { get; set; }

    [JsonPropertyName("expressRouteConnections")]
    public List<ExpressRouteConnectionModel>? ExpressRouteConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("virtualHub")]
    [Required]
    public VirtualHubIdModel VirtualHub { get; set; }
}
