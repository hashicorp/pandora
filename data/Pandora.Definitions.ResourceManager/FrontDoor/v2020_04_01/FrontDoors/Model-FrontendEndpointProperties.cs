using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;


internal class FrontendEndpointPropertiesModel
{
    [JsonPropertyName("customHttpsConfiguration")]
    public CustomHTTPSConfigurationModel? CustomHTTPSConfiguration { get; set; }

    [JsonPropertyName("customHttpsProvisioningState")]
    public CustomHTTPSProvisioningStateConstant? CustomHTTPSProvisioningState { get; set; }

    [JsonPropertyName("customHttpsProvisioningSubstate")]
    public CustomHTTPSProvisioningSubstateConstant? CustomHTTPSProvisioningSubstate { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("resourceState")]
    public FrontDoorResourceStateConstant? ResourceState { get; set; }

    [JsonPropertyName("sessionAffinityEnabledState")]
    public SessionAffinityEnabledStateConstant? SessionAffinityEnabledState { get; set; }

    [JsonPropertyName("sessionAffinityTtlSeconds")]
    public int? SessionAffinityTtlSeconds { get; set; }

    [JsonPropertyName("webApplicationFirewallPolicyLink")]
    public FrontendEndpointUpdateParametersWebApplicationFirewallPolicyLinkModel? WebApplicationFirewallPolicyLink { get; set; }
}
