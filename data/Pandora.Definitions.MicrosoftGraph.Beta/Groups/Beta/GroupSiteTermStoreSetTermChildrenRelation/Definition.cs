// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreSetTermChildrenRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetTermChildrenRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
