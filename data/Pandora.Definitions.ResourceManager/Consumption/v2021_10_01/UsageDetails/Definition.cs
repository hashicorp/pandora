using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.UsageDetails;

internal class Definition : ResourceDefinition
{
    public string Name => "UsageDetails";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(MetrictypeConstant),
        typeof(PricingModelTypeConstant),
        typeof(UsageDetailsKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(LegacyUsageDetailModel),
        typeof(LegacyUsageDetailPropertiesModel),
        typeof(MeterDetailsResponseModel),
        typeof(ModernUsageDetailModel),
        typeof(ModernUsageDetailPropertiesModel),
        typeof(UsageDetailModel),
    };
}
