// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSet;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSet";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdSetOperation(),
        new CreateGroupByIdSiteByIdTermStoreSetOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdSetByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetCountOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdSetsOperation(),
        new ListGroupByIdSiteByIdTermStoreSetsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdSetByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
