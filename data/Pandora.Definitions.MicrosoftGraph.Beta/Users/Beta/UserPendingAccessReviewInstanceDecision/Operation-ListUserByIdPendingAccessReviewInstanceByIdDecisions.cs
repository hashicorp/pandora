// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstanceDecision;

internal class ListUserByIdPendingAccessReviewInstanceByIdDecisionsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdPendingAccessReviewInstanceId();
    public override Type NestedItemType() => typeof(AccessReviewInstanceDecisionItemCollectionResponseModel);
    public override string? UriSuffix() => "/decisions";
}
