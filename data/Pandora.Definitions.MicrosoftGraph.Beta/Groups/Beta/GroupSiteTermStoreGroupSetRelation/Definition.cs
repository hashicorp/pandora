// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreGroupSetRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroupSetRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreGroupByIdSetByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdSetByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreGroupByIdSetByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdSetByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
