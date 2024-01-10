// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreGroupSetChildrenRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroupSetChildrenRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
