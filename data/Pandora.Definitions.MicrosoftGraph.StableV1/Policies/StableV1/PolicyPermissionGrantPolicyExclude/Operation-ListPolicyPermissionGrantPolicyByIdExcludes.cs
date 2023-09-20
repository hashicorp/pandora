// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyPermissionGrantPolicyExclude;

internal class ListPolicyPermissionGrantPolicyByIdExcludesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new PolicyPermissionGrantPolicyId();
    public override Type NestedItemType() => typeof(PermissionGrantConditionSetCollectionResponseModel);
    public override string? UriSuffix() => "/excludes";
}
