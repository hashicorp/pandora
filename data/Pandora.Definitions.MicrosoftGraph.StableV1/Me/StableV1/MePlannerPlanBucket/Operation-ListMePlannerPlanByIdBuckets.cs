// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MePlannerPlanBucket;

internal class ListMePlannerPlanByIdBucketsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new MePlannerPlanId();
    public override Type NestedItemType() => typeof(PlannerBucketCollectionResponseModel);
    public override string? UriSuffix() => "/buckets";
}
