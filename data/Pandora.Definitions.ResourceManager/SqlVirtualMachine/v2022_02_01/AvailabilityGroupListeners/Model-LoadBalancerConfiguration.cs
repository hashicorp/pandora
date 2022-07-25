using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.AvailabilityGroupListeners;


internal class LoadBalancerConfigurationModel
{
    [JsonPropertyName("loadBalancerResourceId")]
    public string? LoadBalancerResourceId { get; set; }

    [JsonPropertyName("privateIpAddress")]
    public PrivateIPAddressModel? PrivateIpAddress { get; set; }

    [JsonPropertyName("probePort")]
    public int? ProbePort { get; set; }

    [JsonPropertyName("publicIpAddressResourceId")]
    public string? PublicIpAddressResourceId { get; set; }

    [JsonPropertyName("sqlVirtualMachineInstances")]
    public List<string>? SqlVirtualMachineInstances { get; set; }
}
