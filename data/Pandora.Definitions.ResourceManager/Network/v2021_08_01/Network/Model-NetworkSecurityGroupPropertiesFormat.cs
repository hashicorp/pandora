using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;


internal class NetworkSecurityGroupPropertiesFormatModel
{
    [JsonPropertyName("defaultSecurityRules")]
    public List<SecurityRuleModel>? DefaultSecurityRules { get; set; }

    [JsonPropertyName("flowLogs")]
    public List<FlowLogModel>? FlowLogs { get; set; }

    [JsonPropertyName("networkInterfaces")]
    public List<NetworkInterfaceModel>? NetworkInterfaces { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }

    [JsonPropertyName("securityRules")]
    public List<SecurityRuleModel>? SecurityRules { get; set; }

    [JsonPropertyName("subnets")]
    public List<SubnetModel>? Subnets { get; set; }
}
