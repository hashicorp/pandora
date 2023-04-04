using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.PowerBIDedicated;

internal class Definition : ResourceDefinition
{
    public string Name => "PowerBIDedicated";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CapacitiesListSkusOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CapacitySkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CapacitySkuModel),
        typeof(SkuEnumerationForNewResourceResultModel),
    };
}
