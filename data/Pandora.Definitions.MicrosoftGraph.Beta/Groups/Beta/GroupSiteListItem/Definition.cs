// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteListItem;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteListItem";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdListByIdItemByIdCreateLinkOperation(),
        new CreateGroupByIdSiteByIdListByIdItemOperation(),
        new DeleteGroupByIdSiteByIdListByIdItemByIdOperation(),
        new GetGroupByIdSiteByIdListByIdItemByIdOperation(),
        new ListGroupByIdSiteByIdListByIdItemsOperation(),
        new UpdateGroupByIdSiteByIdListByIdItemByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdSiteByIdListByIdItemByIdCreateLinkRequestModel)
    };
}
