using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.Charges;

internal class Definition : ResourceDefinition
{
    public string Name => "Charges";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ChargeSummaryKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AmountModel),
        typeof(ChargeSummaryModel),
        typeof(ChargesListResultModel),
        typeof(LegacyChargeSummaryModel),
        typeof(LegacyChargeSummaryPropertiesModel),
        typeof(ModernChargeSummaryModel),
        typeof(ModernChargeSummaryPropertiesModel),
    };
}
