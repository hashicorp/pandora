// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreGroupSetChildrenChildren;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroupSetChildrenChildren";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdChildrenByIdChildrenOperation(),
        new CreateGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdChildrenOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdChildrenByIdChildrenByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdChildrenByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdChildrenByIdChildrenCountOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdChildrenCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdChildrenByIdChildrensOperation(),
        new ListGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdChildrensOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdChildrenByIdChildrenByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdChildrenByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
