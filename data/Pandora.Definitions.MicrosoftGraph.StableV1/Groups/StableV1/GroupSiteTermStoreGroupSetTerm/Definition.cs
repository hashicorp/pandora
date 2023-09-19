// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreGroupSetTerm;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroupSetTerm";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermOperation(),
        new CreateGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermCountOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermsOperation(),
        new ListGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
