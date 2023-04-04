using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.SKUs;

internal class Definition : ResourceDefinition
{
    public string Name => "SKUs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ReasonCodeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ResourceSkuModel),
        typeof(ResourceSkuCapabilitiesModel),
        typeof(ResourceSkuLocationInfoModel),
        typeof(RestrictionModel),
    };
}
