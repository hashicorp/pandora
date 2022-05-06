using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors;


internal class FrontDoorPropertiesModel
{
    [JsonPropertyName("backendPools")]
    public List<BackendPoolModel>? BackendPools { get; set; }

    [JsonPropertyName("backendPoolsSettings")]
    public BackendPoolsSettingsModel? BackendPoolsSettings { get; set; }

    [JsonPropertyName("cname")]
    public string? Cname { get; set; }

    [JsonPropertyName("enabledState")]
    public FrontDoorEnabledStateConstant? EnabledState { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("frontdoorId")]
    public string? FrontdoorId { get; set; }

    [JsonPropertyName("frontendEndpoints")]
    public List<FrontendEndpointModel>? FrontendEndpoints { get; set; }

    [JsonPropertyName("healthProbeSettings")]
    public List<HealthProbeSettingsModelModel>? HealthProbeSettings { get; set; }

    [JsonPropertyName("loadBalancingSettings")]
    public List<LoadBalancingSettingsModelModel>? LoadBalancingSettings { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("resourceState")]
    public FrontDoorResourceStateConstant? ResourceState { get; set; }

    [JsonPropertyName("routingRules")]
    public List<RoutingRuleModel>? RoutingRules { get; set; }

    [JsonPropertyName("rulesEngines")]
    public List<RulesEngineModel>? RulesEngines { get; set; }
}
