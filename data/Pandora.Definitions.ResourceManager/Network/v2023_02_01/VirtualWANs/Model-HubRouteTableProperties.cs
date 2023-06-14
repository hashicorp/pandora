using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.VirtualWANs;


internal class HubRouteTablePropertiesModel
{
    [JsonPropertyName("associatedConnections")]
    public List<string>? AssociatedConnections { get; set; }

    [JsonPropertyName("labels")]
    public List<string>? Labels { get; set; }

    [JsonPropertyName("propagatingConnections")]
    public List<string>? PropagatingConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("routes")]
    public List<HubRouteModel>? Routes { get; set; }
}
