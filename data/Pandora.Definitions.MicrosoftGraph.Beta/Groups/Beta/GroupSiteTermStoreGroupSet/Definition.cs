// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreGroupSet;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroupSet";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreGroupByIdSetOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetCountOperation(),
        new ListGroupByIdSiteByIdTermStoreGroupByIdSetsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdSetByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
