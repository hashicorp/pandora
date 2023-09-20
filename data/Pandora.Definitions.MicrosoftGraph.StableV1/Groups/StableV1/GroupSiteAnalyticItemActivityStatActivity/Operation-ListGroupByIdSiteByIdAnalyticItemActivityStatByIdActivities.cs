// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteAnalyticItemActivityStatActivity;

internal class ListGroupByIdSiteByIdAnalyticItemActivityStatByIdActivitiesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdSiteIdAnalyticItemActivityStatId();
    public override Type NestedItemType() => typeof(ItemActivityCollectionResponseModel);
    public override string? UriSuffix() => "/activities";
}
