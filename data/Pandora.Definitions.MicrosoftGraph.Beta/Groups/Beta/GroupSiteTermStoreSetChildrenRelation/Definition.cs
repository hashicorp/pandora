// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreSetChildrenRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetChildrenRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreSetByIdChildrenByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdChildrenByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdChildrenByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
