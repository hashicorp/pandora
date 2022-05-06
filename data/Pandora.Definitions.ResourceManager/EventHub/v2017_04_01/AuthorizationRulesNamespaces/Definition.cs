using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesNamespaces;

internal class Definition : ResourceDefinition
{
    public string Name => "AuthorizationRulesNamespaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new NamespacesCreateOrUpdateAuthorizationRuleOperation(),
        new NamespacesDeleteAuthorizationRuleOperation(),
        new NamespacesGetAuthorizationRuleOperation(),
        new NamespacesListAuthorizationRulesOperation(),
        new NamespacesListKeysOperation(),
        new NamespacesRegenerateKeysOperation(),
    };
}
