using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Relay.v2021_11_01.Namespaces;

internal class Definition : ResourceDefinition
{
    public string Name => "Namespaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new CreateOrUpdateAuthorizationRuleOperation(),
        new CreateOrUpdateNetworkRuleSetOperation(),
        new DeleteOperation(),
        new DeleteAuthorizationRuleOperation(),
        new GetOperation(),
        new GetAuthorizationRuleOperation(),
        new GetNetworkRuleSetOperation(),
        new ListOperation(),
        new ListAuthorizationRulesOperation(),
        new ListByResourceGroupOperation(),
        new ListKeysOperation(),
        new RegenerateKeysOperation(),
        new UpdateOperation(),
    };
}
