using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SystemCenterVirtualMachineManager.v2023_10_07.VirtualMachineInstances;


internal class VirtualMachineInstanceUpdatePropertiesModel
{
    [JsonPropertyName("availabilitySets")]
    public List<AvailabilitySetListAvailabilitySetsInlinedModel>? AvailabilitySets { get; set; }

    [JsonPropertyName("hardwareProfile")]
    public HardwareProfileUpdateModel? HardwareProfile { get; set; }

    [JsonPropertyName("infrastructureProfile")]
    public InfrastructureProfileUpdateModel? InfrastructureProfile { get; set; }

    [JsonPropertyName("networkProfile")]
    public NetworkProfileUpdateModel? NetworkProfile { get; set; }

    [JsonPropertyName("storageProfile")]
    public StorageProfileUpdateModel? StorageProfile { get; set; }
}
