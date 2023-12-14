// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreGroup;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroup";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdGroupOperation(),
        new CreateGroupByIdSiteByIdTermStoreGroupOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdGroupByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupCountOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdGroupsOperation(),
        new ListGroupByIdSiteByIdTermStoreGroupsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdGroupByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
