// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyPermissionGrantPolicyInclude;

internal class ListPolicyPermissionGrantPolicyByIdIncludesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new PolicyPermissionGrantPolicyId();
    public override Type NestedItemType() => typeof(PermissionGrantConditionSetCollectionResponseModel);
    public override string? UriSuffix() => "/includes";
}
