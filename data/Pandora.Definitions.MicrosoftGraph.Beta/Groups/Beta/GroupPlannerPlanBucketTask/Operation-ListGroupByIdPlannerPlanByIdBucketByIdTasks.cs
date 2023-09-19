// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupPlannerPlanBucketTask;

internal class ListGroupByIdPlannerPlanByIdBucketByIdTasksOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdPlannerPlanIdBucketId();
    public override Type NestedItemType() => typeof(PlannerTaskCollectionResponseModel);
    public override string? UriSuffix() => "/tasks";
}
