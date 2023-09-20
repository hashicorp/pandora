// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSetParentGroupSetChildrenRelation;

internal class ListGroupByIdSiteByIdTermStoreByIdSetByIdParentGroupSetByIdChildrenByIdRelationsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdSiteIdTermStoreIdSetIdParentGroupSetIdChildrenId();
    public override Type NestedItemType() => typeof(TermStoreRelationCollectionResponseModel);
    public override string? UriSuffix() => "/relations";
}
