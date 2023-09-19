// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSetTermRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetTermRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdRelationOperation(),
        new CreateGroupByIdSiteByIdTermStoreSetByIdTermByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdRelationByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdTermByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdRelationCountOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdTermByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdTermByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdRelationsOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdTermByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdRelationByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdTermByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
