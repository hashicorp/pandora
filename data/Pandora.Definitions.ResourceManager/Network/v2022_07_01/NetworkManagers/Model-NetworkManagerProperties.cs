using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkManagers;


internal class NetworkManagerPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("networkManagerScopeAccesses")]
    [Required]
    public List<ConfigurationTypeConstant> NetworkManagerScopeAccesses { get; set; }

    [JsonPropertyName("networkManagerScopes")]
    [Required]
    public NetworkManagerPropertiesNetworkManagerScopesModel NetworkManagerScopes { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
