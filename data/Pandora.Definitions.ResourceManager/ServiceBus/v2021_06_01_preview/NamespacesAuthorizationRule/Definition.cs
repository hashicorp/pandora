using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_06_01_preview.NamespacesAuthorizationRule;

internal class Definition : ResourceDefinition
{
    public string Name => "NamespacesAuthorizationRule";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new NamespacesCreateOrUpdateAuthorizationRuleOperation(),
        new NamespacesDeleteAuthorizationRuleOperation(),
        new NamespacesGetAuthorizationRuleOperation(),
        new NamespacesListAuthorizationRulesOperation(),
        new NamespacesListKeysOperation(),
        new NamespacesRegenerateKeysOperation(),
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
