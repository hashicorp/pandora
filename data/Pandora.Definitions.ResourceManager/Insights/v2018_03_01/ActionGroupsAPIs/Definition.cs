using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01.ActionGroupsAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "ActionGroupsAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ActionGroupsCreateOrUpdateOperation(),
        new ActionGroupsDeleteOperation(),
        new ActionGroupsEnableReceiverOperation(),
        new ActionGroupsGetOperation(),
        new ActionGroupsListByResourceGroupOperation(),
        new ActionGroupsListBySubscriptionIdOperation(),
        new ActionGroupsUpdateOperation(),
    };
}
