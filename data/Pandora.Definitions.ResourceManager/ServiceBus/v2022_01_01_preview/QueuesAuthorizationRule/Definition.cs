using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2022_01_01_preview.QueuesAuthorizationRule;

internal class Definition : ResourceDefinition
{
    public string Name => "QueuesAuthorizationRule";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new QueuesCreateOrUpdateAuthorizationRuleOperation(),
        new QueuesDeleteAuthorizationRuleOperation(),
        new QueuesGetAuthorizationRuleOperation(),
        new QueuesListAuthorizationRulesOperation(),
        new QueuesListKeysOperation(),
        new QueuesRegenerateKeysOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessRightsConstant),
        typeof(KeyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessKeysModel),
        typeof(RegenerateAccessKeyParametersModel),
        typeof(SBAuthorizationRuleModel),
        typeof(SBAuthorizationRulePropertiesModel),
    };
}
