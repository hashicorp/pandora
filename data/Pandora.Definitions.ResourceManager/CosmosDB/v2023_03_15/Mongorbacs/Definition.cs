using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_03_15.Mongorbacs;

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
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(MongoRoleDefinitionTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(MongoRoleDefinitionCreateUpdateParametersModel),
        typeof(MongoRoleDefinitionGetResultsModel),
        typeof(MongoRoleDefinitionListResultModel),
        typeof(MongoRoleDefinitionResourceModel),
        typeof(MongoUserDefinitionCreateUpdateParametersModel),
        typeof(MongoUserDefinitionGetResultsModel),
        typeof(MongoUserDefinitionListResultModel),
        typeof(MongoUserDefinitionResourceModel),
        typeof(PrivilegeModel),
        typeof(PrivilegeResourceModel),
        typeof(RoleModel),
    };
}
