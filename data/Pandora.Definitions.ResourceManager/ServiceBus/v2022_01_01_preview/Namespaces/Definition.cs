using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2022_01_01_preview.Namespaces;

internal class Definition : ResourceDefinition
{
    public string Name => "Namespaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new CreateOrUpdateNetworkRuleSetOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetNetworkRuleSetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListNetworkRuleSetsOperation(),
        new UpdateOperation(),
    };
}
