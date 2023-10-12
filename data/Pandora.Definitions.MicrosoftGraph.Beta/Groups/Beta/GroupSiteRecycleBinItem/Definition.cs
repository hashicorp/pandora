// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteRecycleBinItem;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteRecycleBinItem";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdRecycleBinItemOperation(),
        new DeleteGroupByIdSiteByIdRecycleBinItemByIdOperation(),
        new GetGroupByIdSiteByIdRecycleBinItemByIdOperation(),
        new GetGroupByIdSiteByIdRecycleBinItemCountOperation(),
        new ListGroupByIdSiteByIdRecycleBinItemsOperation(),
        new UpdateGroupByIdSiteByIdRecycleBinItemByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
