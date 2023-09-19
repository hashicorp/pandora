// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstanceStageDecision;

internal class ListUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdPendingAccessReviewInstanceIdStageId();
    public override Type NestedItemType() => typeof(AccessReviewInstanceDecisionItemCollectionResponseModel);
    public override string? UriSuffix() => "/decisions";
}
