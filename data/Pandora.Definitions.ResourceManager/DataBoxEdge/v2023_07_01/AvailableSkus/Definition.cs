using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2023_07_01.AvailableSkus;

internal class Definition : ResourceDefinition
{
    public string Name => "AvailableSkus";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ShipmentTypeConstant),
        typeof(SkuAvailabilityConstant),
        typeof(SkuNameConstant),
        typeof(SkuSignupOptionConstant),
        typeof(SkuTierConstant),
        typeof(SkuVersionConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataBoxEdgeSkuModel),
        typeof(SkuCapabilityModel),
        typeof(SkuCostModel),
        typeof(SkuLocationInfoModel),
    };
}
