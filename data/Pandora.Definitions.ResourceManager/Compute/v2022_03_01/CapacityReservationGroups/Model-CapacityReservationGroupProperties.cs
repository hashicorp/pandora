using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.CapacityReservationGroups;


internal class CapacityReservationGroupPropertiesModel
{
    [JsonPropertyName("capacityReservations")]
    public List<SubResourceReadOnlyModel>? CapacityReservations { get; set; }

    [JsonPropertyName("instanceView")]
    public CapacityReservationGroupInstanceViewModel? InstanceView { get; set; }

    [JsonPropertyName("virtualMachinesAssociated")]
    public List<SubResourceReadOnlyModel>? VirtualMachinesAssociated { get; set; }
}
