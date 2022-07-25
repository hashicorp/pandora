using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.AvailabilityGroupListeners;


internal class AvailabilityGroupListenerPropertiesModel
{
    [JsonPropertyName("availabilityGroupConfiguration")]
    public AgConfigurationModel? AvailabilityGroupConfiguration { get; set; }

    [JsonPropertyName("availabilityGroupName")]
    public string? AvailabilityGroupName { get; set; }

    [JsonPropertyName("createDefaultAvailabilityGroupIfNotExist")]
    public bool? CreateDefaultAvailabilityGroupIfNotExist { get; set; }

    [JsonPropertyName("loadBalancerConfigurations")]
    public List<LoadBalancerConfigurationModel>? LoadBalancerConfigurations { get; set; }

    [JsonPropertyName("multiSubnetIpConfigurations")]
    public List<MultiSubnetIpConfigurationModel>? MultiSubnetIpConfigurations { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }
}
