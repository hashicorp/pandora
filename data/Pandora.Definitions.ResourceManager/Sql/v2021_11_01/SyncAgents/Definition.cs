using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.SyncAgents;

internal class Definition : ResourceDefinition
{
    public string Name => "SyncAgents";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GenerateKeyOperation(),
        new GetOperation(),
        new ListByServerOperation(),
        new ListLinkedDatabasesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SyncAgentStateConstant),
        typeof(SyncMemberDbTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SyncAgentModel),
        typeof(SyncAgentKeyPropertiesModel),
        typeof(SyncAgentLinkedDatabaseModel),
        typeof(SyncAgentLinkedDatabasePropertiesModel),
        typeof(SyncAgentPropertiesModel),
    };
}
