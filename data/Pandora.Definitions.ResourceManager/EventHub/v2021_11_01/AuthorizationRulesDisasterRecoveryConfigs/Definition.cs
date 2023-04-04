using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.AuthorizationRulesDisasterRecoveryConfigs;

internal class Definition : ResourceDefinition
{
    public string Name => "AuthorizationRulesDisasterRecoveryConfigs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DisasterRecoveryConfigsGetAuthorizationRuleOperation(),
        new DisasterRecoveryConfigsListAuthorizationRulesOperation(),
        new DisasterRecoveryConfigsListKeysOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessRightsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessKeysModel),
        typeof(AuthorizationRuleModel),
        typeof(AuthorizationRulePropertiesModel),
    };
}
