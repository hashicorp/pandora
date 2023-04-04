using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.HybridConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "HybridConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new CreateOrUpdateAuthorizationRuleOperation(),
        new DeleteOperation(),
        new DeleteAuthorizationRuleOperation(),
        new GetOperation(),
        new GetAuthorizationRuleOperation(),
        new ListAuthorizationRulesOperation(),
        new ListByNamespaceOperation(),
        new ListKeysOperation(),
        new RegenerateKeysOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessRightsConstant),
        typeof(KeyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessKeysModel),
        typeof(AuthorizationRuleModel),
        typeof(AuthorizationRulePropertiesModel),
        typeof(HybridConnectionModel),
        typeof(HybridConnectionPropertiesModel),
        typeof(RegenerateAccessKeyParametersModel),
    };
}
