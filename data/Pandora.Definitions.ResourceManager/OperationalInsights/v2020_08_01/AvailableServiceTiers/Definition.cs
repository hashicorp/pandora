using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.AvailableServiceTiers;

internal class Definition : ResourceDefinition
{
    public string Name => "AvailableServiceTiers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByWorkspaceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataSourceTypeConstant),
        typeof(SkuNameEnumConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AvailableServiceTierModel),
    };
}
