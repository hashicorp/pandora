// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyFeatureRolloutPolicyAppliesTo;

internal class ListPolicyFeatureRolloutPolicyByIdAppliesToRefsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new PolicyFeatureRolloutPolicyId();
    public override Type NestedItemType() => typeof(StringCollectionResponseModel);
    public override string? UriSuffix() => "/appliesTo/$ref";
}
