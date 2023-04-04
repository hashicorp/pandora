using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2020_10_05_privatepreview.Servers;

internal class Definition : ResourceDefinition
{
    public string Name => "Servers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListByServerGroupOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CitusVersionConstant),
        typeof(PostgreSQLVersionConstant),
        typeof(ServerEditionConstant),
        typeof(ServerHaStateConstant),
        typeof(ServerRoleConstant),
        typeof(ServerStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ServerGroupServerModel),
        typeof(ServerGroupServerListResultModel),
        typeof(ServerGroupServerPropertiesModel),
    };
}
