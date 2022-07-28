using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ExpressRouteCrossConnectionArpTable;


internal class ExpressRouteCircuitArpTableModel
{
    [JsonPropertyName("age")]
    public int? Age { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("interface")]
    public string? Interface { get; set; }

    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; set; }
}
