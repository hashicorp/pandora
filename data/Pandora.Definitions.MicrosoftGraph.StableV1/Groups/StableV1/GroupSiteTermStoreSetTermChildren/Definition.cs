// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSetTermChildren;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetTermChildren";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdChildrenOperation(),
        new CreateGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdChildrenByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdChildrenCountOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdChildrensOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrensOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdChildrenByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
