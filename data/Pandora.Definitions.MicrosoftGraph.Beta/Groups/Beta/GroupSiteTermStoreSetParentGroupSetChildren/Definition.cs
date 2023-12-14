// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreSetParentGroupSetChildren;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetParentGroupSetChildren";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenCountOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrensOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
