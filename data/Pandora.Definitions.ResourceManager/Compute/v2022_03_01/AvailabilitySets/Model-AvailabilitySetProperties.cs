using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.AvailabilitySets;


internal class AvailabilitySetPropertiesModel
{
    [JsonPropertyName("platformFaultDomainCount")]
    public int? PlatformFaultDomainCount { get; set; }

    [JsonPropertyName("platformUpdateDomainCount")]
    public int? PlatformUpdateDomainCount { get; set; }

    [JsonPropertyName("proximityPlacementGroup")]
    public SubResourceModel? ProximityPlacementGroup { get; set; }

    [JsonPropertyName("statuses")]
    public List<InstanceViewStatusModel>? Statuses { get; set; }

    [JsonPropertyName("virtualMachines")]
    public List<SubResourceModel>? VirtualMachines { get; set; }
}
