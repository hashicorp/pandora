using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.ResourceSkus;

internal class Definition : ResourceDefinition
{
    public string Name => "ResourceSkus";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ResourceSkuRestrictionsReasonCodeConstant),
        typeof(ResourceSkuRestrictionsTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ResourceSkuCapabilityModel),
        typeof(ResourceSkuInfoModel),
        typeof(ResourceSkuLocationInfoModel),
        typeof(ResourceSkuRestrictionInfoModel),
        typeof(ResourceSkuRestrictionsModel),
        typeof(ResourceSkuZoneDetailsModel),
    };
}
