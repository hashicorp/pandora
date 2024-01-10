// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreSetParentGroupSetChildrenRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetParentGroupSetChildrenRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
