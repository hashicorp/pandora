using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2023_05_01.ReservationSummaries;

internal class Definition : ResourceDefinition
{
    public string Name => "ReservationSummaries";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ReservationsSummariesListOperation(),
        new ReservationsSummariesListByReservationOrderOperation(),
        new ReservationsSummariesListByReservationOrderAndReservationOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DatagrainConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ReservationSummaryModel),
        typeof(ReservationSummaryPropertiesModel),
    };
}
