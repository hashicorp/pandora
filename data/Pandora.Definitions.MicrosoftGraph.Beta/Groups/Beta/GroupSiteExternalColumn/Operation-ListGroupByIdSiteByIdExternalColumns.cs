// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteExternalColumn;

internal class ListGroupByIdSiteByIdExternalColumnsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdSiteId();
    public override Type NestedItemType() => typeof(ColumnDefinitionCollectionResponseModel);
    public override string? UriSuffix() => "/externalColumns";
}
