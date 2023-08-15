using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.BenefitUtilizationSummariesAsync;

internal class ReservationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftCapacity", "Microsoft.Capacity"),
        ResourceIDSegment.Static("staticReservationOrders", "reservationOrders"),
        ResourceIDSegment.UserSpecified("reservationOrderId"),
        ResourceIDSegment.Static("staticReservations", "reservations"),
        ResourceIDSegment.UserSpecified("reservationId"),
    };
}
