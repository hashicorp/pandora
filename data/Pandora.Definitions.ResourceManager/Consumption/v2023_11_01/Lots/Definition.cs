using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2023_11_01.Lots;

internal class Definition : ResourceDefinition
{
    public string Name => "Lots";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByBillingAccountOperation(),
        new ListByBillingProfileOperation(),
        new ListByCustomerOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(LotSourceConstant),
        typeof(OrgTypeConstant),
        typeof(StatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AmountModel),
        typeof(AmountWithExchangeRateModel),
        typeof(LotPropertiesModel),
        typeof(LotSummaryModel),
        typeof(ResellerModel),
    };
}
