// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteTermStoreSetChildrenChildren;

internal class ListGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrensOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdSiteIdTermStoreSetIdChildrenId();
    public override Type NestedItemType() => typeof(TermStoreTermCollectionResponseModel);
    public override string? UriSuffix() => "/children";
}
