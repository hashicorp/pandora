using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_05_01.ManagementLocks;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagementLocks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateAtResourceGroupLevelOperation(),
        new CreateOrUpdateAtResourceLevelOperation(),
        new CreateOrUpdateAtSubscriptionLevelOperation(),
        new CreateOrUpdateByScopeOperation(),
        new DeleteAtResourceGroupLevelOperation(),
        new DeleteAtResourceLevelOperation(),
        new DeleteAtSubscriptionLevelOperation(),
        new DeleteByScopeOperation(),
        new GetAtResourceGroupLevelOperation(),
        new GetAtResourceLevelOperation(),
        new GetAtSubscriptionLevelOperation(),
        new GetByScopeOperation(),
        new ListAtResourceGroupLevelOperation(),
        new ListAtResourceLevelOperation(),
        new ListAtSubscriptionLevelOperation(),
        new ListByScopeOperation(),
    };
}
