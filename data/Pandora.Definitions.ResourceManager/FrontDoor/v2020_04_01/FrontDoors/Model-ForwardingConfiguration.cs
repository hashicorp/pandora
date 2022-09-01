using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;

[ValueForType("#Microsoft.Azure.FrontDoor.Models.FrontdoorForwardingConfiguration")]
internal class ForwardingConfigurationModel : RouteConfigurationModel
{
    [JsonPropertyName("backendPool")]
    public SubResourceModel? BackendPool { get; set; }

    [JsonPropertyName("cacheConfiguration")]
    public CacheConfigurationModel? CacheConfiguration { get; set; }

    [JsonPropertyName("customForwardingPath")]
    public string? CustomForwardingPath { get; set; }

    [JsonPropertyName("forwardingProtocol")]
    public FrontDoorForwardingProtocolConstant? ForwardingProtocol { get; set; }
}
