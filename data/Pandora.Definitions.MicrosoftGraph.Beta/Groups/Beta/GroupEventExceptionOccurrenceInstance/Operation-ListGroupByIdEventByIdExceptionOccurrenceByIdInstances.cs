// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupEventExceptionOccurrenceInstance;

internal class ListGroupByIdEventByIdExceptionOccurrenceByIdInstancesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdEventIdExceptionOccurrenceId();
    public override Type NestedItemType() => typeof(EventCollectionResponseModel);
    public override string? UriSuffix() => "/instances";
}
