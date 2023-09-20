// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreSetParentGroupSet;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetParentGroupSet";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetCountOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdParentGroupSetsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
