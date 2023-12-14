// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreSetChildrenChildren;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetChildrenChildren";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenCountOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrensOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
