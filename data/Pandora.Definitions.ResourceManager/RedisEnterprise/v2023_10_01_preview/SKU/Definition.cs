using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_10_01_preview.SKU;

internal class Definition : ResourceDefinition
{
    public string Name => "SKU";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SkuNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CapabilityModel),
        typeof(LocationInfoModel),
        typeof(RegionSkuDetailModel),
        typeof(RegionSkuDetailsModel),
        typeof(SkuDetailModel),
    };
}
