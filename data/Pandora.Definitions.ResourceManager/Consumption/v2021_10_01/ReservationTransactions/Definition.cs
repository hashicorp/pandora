using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.ReservationTransactions;

internal class Definition : ResourceDefinition
{
    public string Name => "ReservationTransactions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
        new ListByBillingProfileOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(LegacyReservationTransactionPropertiesModel),
        typeof(ModernReservationTransactionModel),
        typeof(ModernReservationTransactionPropertiesModel),
        typeof(ReservationTransactionModel),
    };
}
