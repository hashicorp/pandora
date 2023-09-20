// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreGroupSetTermChildren;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroupSetTermChildren";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdChildrenOperation(),
        new CreateGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdChildrenOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdChildrenByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdChildrenCountOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdChildrenCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdChildrensOperation(),
        new ListGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdChildrensOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdChildrenByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdChildrenByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
