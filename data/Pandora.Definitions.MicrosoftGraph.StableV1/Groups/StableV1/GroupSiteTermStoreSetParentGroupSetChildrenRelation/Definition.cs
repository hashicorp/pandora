// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSetParentGroupSetChildrenRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetParentGroupSetChildrenRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdRelationOperation(),
        new CreateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdRelationByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdRelationCountOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdRelationsOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdRelationByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
