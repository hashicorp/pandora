// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreGroupSetRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroupSetRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdRelationOperation(),
        new CreateGroupByIdSiteByIdTermStoreGroupByIdSetByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdRelationByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdSetByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdRelationCountOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdRelationsOperation(),
        new ListGroupByIdSiteByIdTermStoreGroupByIdSetByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdRelationByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdSetByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
