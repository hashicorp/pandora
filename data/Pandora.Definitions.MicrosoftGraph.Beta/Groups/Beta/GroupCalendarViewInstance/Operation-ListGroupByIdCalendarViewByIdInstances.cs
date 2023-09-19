// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarViewInstance;

internal class ListGroupByIdCalendarViewByIdInstancesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdCalendarViewId();
    public override Type NestedItemType() => typeof(EventCollectionResponseModel);
    public override string? UriSuffix() => "/instances";
}
