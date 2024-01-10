// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteListSubscription;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteListSubscription";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdListByIdSubscriptionByIdReauthorizeOperation(),
        new CreateGroupByIdSiteByIdListByIdSubscriptionOperation(),
        new DeleteGroupByIdSiteByIdListByIdSubscriptionByIdOperation(),
        new GetGroupByIdSiteByIdListByIdSubscriptionByIdOperation(),
        new GetGroupByIdSiteByIdListByIdSubscriptionCountOperation(),
        new ListGroupByIdSiteByIdListByIdSubscriptionsOperation(),
        new UpdateGroupByIdSiteByIdListByIdSubscriptionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
