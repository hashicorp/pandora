// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSetParentGroupSet;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetParentGroupSet";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetOperation(),
        new CreateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetCountOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetsOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdParentGroupSetsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
