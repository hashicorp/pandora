using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;


internal class RoutingRulePropertiesModel
{
    [JsonPropertyName("acceptedProtocols")]
    public List<FrontDoorProtocolConstant>? AcceptedProtocols { get; set; }

    [JsonPropertyName("enabledState")]
    public RoutingRuleEnabledStateConstant? EnabledState { get; set; }

    [JsonPropertyName("frontendEndpoints")]
    public List<SubResourceModel>? FrontendEndpoints { get; set; }

    [JsonPropertyName("patternsToMatch")]
    public List<string>? PatternsToMatch { get; set; }

    [JsonPropertyName("resourceState")]
    public FrontDoorResourceStateConstant? ResourceState { get; set; }

    [JsonPropertyName("routeConfiguration")]
    public RouteConfigurationModel? RouteConfiguration { get; set; }

    [JsonPropertyName("rulesEngine")]
    public SubResourceModel? RulesEngine { get; set; }

    [JsonPropertyName("webApplicationFirewallPolicyLink")]
    public RoutingRuleUpdateParametersWebApplicationFirewallPolicyLinkModel? WebApplicationFirewallPolicyLink { get; set; }
}
