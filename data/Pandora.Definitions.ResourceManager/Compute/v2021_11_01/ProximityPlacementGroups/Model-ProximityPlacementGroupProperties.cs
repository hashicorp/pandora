using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.ProximityPlacementGroups;


internal class ProximityPlacementGroupPropertiesModel
{
    [JsonPropertyName("availabilitySets")]
    public List<SubResourceWithColocationStatusModel>? AvailabilitySets { get; set; }

    [JsonPropertyName("colocationStatus")]
    public InstanceViewStatusModel? ColocationStatus { get; set; }

    [JsonPropertyName("proximityPlacementGroupType")]
    public ProximityPlacementGroupTypeConstant? ProximityPlacementGroupType { get; set; }

    [JsonPropertyName("virtualMachineScaleSets")]
    public List<SubResourceWithColocationStatusModel>? VirtualMachineScaleSets { get; set; }

    [JsonPropertyName("virtualMachines")]
    public List<SubResourceWithColocationStatusModel>? VirtualMachines { get; set; }
}
