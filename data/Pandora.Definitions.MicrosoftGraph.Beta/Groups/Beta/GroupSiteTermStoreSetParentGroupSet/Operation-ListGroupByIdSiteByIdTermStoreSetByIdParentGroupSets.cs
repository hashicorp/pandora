// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreSetParentGroupSet;

internal class ListGroupByIdSiteByIdTermStoreSetByIdParentGroupSetsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdSiteIdTermStoreSetId();
    public override Type NestedItemType() => typeof(TermStoreSetCollectionResponseModel);
    public override string? UriSuffix() => "/parentGroup/sets";
}
