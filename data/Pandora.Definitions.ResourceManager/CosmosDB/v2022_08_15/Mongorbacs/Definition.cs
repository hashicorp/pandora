using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.Mongorbacs;

internal class Definition : ResourceDefinition
{
    public string Name => "Mongorbacs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new MongoDBResourcesCreateUpdateMongoRoleDefinitionOperation(),
        new MongoDBResourcesCreateUpdateMongoUserDefinitionOperation(),
        new MongoDBResourcesDeleteMongoRoleDefinitionOperation(),
        new MongoDBResourcesDeleteMongoUserDefinitionOperation(),
        new MongoDBResourcesGetMongoRoleDefinitionOperation(),
        new MongoDBResourcesGetMongoUserDefinitionOperation(),
        new MongoDBResourcesListMongoRoleDefinitionsOperation(),
        new MongoDBResourcesListMongoUserDefinitionsOperation(),
    };
}
