// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSetChildren;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetChildren";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdSetByIdChildrenOperation(),
        new CreateGroupByIdSiteByIdTermStoreSetByIdChildrenOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdChildrenCountOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdSetByIdChildrensOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdChildrensOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdChildrenByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
