// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreGroupSet;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroupSet";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdGroupByIdSetOperation(),
        new CreateGroupByIdSiteByIdTermStoreGroupByIdSetOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetCountOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdGroupByIdSetsOperation(),
        new ListGroupByIdSiteByIdTermStoreGroupByIdSetsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdSetByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
