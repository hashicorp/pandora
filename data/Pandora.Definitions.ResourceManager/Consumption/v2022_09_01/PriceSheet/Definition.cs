using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2022_09_01.PriceSheet;

internal class Definition : ResourceDefinition
{
    public string Name => "PriceSheet";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new GetByBillingPeriodOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(MeterDetailsModel),
        typeof(PriceSheetModelModel),
        typeof(PriceSheetPropertiesModel),
        typeof(PriceSheetResultModel),
        typeof(SavingsPlanModel),
    };
}
