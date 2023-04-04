using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.VirtualNetworkRules;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualNetworkRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByServerOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(VirtualNetworkRuleStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(VirtualNetworkRuleModel),
        typeof(VirtualNetworkRulePropertiesModel),
    };
}
