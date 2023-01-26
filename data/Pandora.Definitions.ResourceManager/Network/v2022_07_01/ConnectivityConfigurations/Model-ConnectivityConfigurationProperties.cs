using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ConnectivityConfigurations;


internal class ConnectivityConfigurationPropertiesModel
{
    [JsonPropertyName("appliesToGroups")]
    [Required]
    public List<ConnectivityGroupItemModel> AppliesToGroups { get; set; }

    [JsonPropertyName("connectivityTopology")]
    [Required]
    public ConnectivityTopologyConstant ConnectivityTopology { get; set; }

    [JsonPropertyName("deleteExistingPeering")]
    public DeleteExistingPeeringConstant? DeleteExistingPeering { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("hubs")]
    public List<HubModel>? Hubs { get; set; }

    [JsonPropertyName("isGlobal")]
    public IsGlobalConstant? IsGlobal { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
