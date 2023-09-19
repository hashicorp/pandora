// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSetRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdSetByIdRelationOperation(),
        new CreateGroupByIdSiteByIdTermStoreSetByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdSetByIdRelationByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdRelationCountOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdSetByIdRelationsOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdSetByIdRelationByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
