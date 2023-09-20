// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSetParentGroupSetChildrenChildrenRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetParentGroupSetChildrenChildrenRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationOperation(),
        new CreateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationCountOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationsOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
