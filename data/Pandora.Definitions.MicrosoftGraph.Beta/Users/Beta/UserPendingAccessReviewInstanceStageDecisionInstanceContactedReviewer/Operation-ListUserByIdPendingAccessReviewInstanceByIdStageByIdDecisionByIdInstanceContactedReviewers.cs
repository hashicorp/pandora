// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstanceStageDecisionInstanceContactedReviewer;

internal class ListUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdInstanceContactedReviewersOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdPendingAccessReviewInstanceIdStageIdDecisionId();
    public override Type NestedItemType() => typeof(AccessReviewReviewerCollectionResponseModel);
    public override string? UriSuffix() => "/instance/contactedReviewers";
}
