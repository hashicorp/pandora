// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSetChildrenChildren;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetChildrenChildren";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdChildrenOperation(),
        new CreateGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdChildrenByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdChildrenCountOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdChildrensOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrensOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdChildrenByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
