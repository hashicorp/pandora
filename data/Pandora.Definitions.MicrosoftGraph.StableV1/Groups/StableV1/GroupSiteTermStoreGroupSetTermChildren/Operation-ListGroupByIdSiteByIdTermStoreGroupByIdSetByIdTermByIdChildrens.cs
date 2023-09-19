// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreGroupSetTermChildren;

internal class ListGroupByIdSiteByIdTermStoreGroupByIdSetByIdTermByIdChildrensOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdSiteIdTermStoreGroupIdSetIdTermId();
    public override Type NestedItemType() => typeof(TermStoreTermCollectionResponseModel);
    public override string? UriSuffix() => "/children";
}
