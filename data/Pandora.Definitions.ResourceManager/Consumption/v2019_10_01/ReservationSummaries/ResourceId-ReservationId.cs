using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.ReservationSummaries;

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
