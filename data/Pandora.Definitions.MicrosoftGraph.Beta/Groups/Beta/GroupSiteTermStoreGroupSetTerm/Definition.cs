// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreGroupSetTerm;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroupSetTerm";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermCountOperation(),
        new ListGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
