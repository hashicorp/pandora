// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteContentTypeColumnLink;

internal class ListGroupByIdSiteByIdContentTypeByIdColumnLinksOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdSiteIdContentTypeId();
    public override Type NestedItemType() => typeof(ColumnLinkCollectionResponseModel);
    public override string? UriSuffix() => "/columnLinks";
}
