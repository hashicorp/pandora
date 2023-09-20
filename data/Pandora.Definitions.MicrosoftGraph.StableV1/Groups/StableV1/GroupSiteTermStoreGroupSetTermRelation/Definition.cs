// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreGroupSetTermRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroupSetTermRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdRelationOperation(),
        new CreateGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdRelationByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdRelationCountOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdRelationsOperation(),
        new ListGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdTermByIdRelationByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
