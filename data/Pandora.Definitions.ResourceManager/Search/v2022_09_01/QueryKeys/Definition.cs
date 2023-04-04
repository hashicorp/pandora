using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2022_09_01.QueryKeys;

internal class Definition : ResourceDefinition
{
    public string Name => "QueryKeys";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new ListBySearchServiceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AdminKeyKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(QueryKeyModel),
    };
}
