using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.CapacityReservations;


internal class CapacityReservationPropertiesModel
{
    [JsonPropertyName("instanceView")]
    public CapacityReservationInstanceViewModel? InstanceView { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("provisioningTime")]
    public DateTime? ProvisioningTime { get; set; }

    [JsonPropertyName("reservationId")]
    public string? ReservationId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeCreated")]
    public DateTime? TimeCreated { get; set; }

    [JsonPropertyName("virtualMachinesAssociated")]
    public List<SubResourceReadOnlyModel>? VirtualMachinesAssociated { get; set; }
}
