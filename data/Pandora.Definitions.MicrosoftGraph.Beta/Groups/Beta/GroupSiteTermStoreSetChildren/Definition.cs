// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreSetChildren;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetChildren";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreSetByIdChildrenOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenCountOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdChildrensOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdChildrenByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
