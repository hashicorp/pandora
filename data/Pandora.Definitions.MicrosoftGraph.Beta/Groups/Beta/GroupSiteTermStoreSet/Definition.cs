// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreSet;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSet";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreSetOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetCountOperation(),
        new ListGroupByIdSiteByIdTermStoreSetsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
