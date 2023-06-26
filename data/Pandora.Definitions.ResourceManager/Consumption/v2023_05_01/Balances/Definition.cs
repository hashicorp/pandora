using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2023_05_01.Balances;

internal class Definition : ResourceDefinition
{
    public string Name => "Balances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetByBillingAccountOperation(),
        new GetForBillingPeriodByBillingAccountOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BillingFrequencyConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BalanceModel),
        typeof(BalancePropertiesModel),
        typeof(BalancePropertiesAdjustmentDetailsInlinedModel),
        typeof(BalancePropertiesNewPurchasesDetailsInlinedModel),
    };
}
