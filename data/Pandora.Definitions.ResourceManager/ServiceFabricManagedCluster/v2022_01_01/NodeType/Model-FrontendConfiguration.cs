using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.NodeType;


internal class FrontendConfigurationModel
{
    [JsonPropertyName("ipAddressType")]
    public IPAddressTypeConstant? IPAddressType { get; set; }

    [JsonPropertyName("loadBalancerBackendAddressPoolId")]
    public string? LoadBalancerBackendAddressPoolId { get; set; }

    [JsonPropertyName("loadBalancerInboundNatPoolId")]
    public string? LoadBalancerInboundNatPoolId { get; set; }
}
