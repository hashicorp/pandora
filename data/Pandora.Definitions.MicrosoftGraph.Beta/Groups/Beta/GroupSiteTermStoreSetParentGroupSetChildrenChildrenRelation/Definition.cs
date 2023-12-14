// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreSetParentGroupSetChildrenChildrenRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetParentGroupSetChildrenChildrenRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdParentGroupSetByIdChildrenByIdChildrenByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
