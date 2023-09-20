// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstanceStageDecisionInstanceDecision;

internal class Definition : ResourceDefinition
{
    public string Name => "UserPendingAccessReviewInstanceStageDecisionInstanceDecision";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdInstanceDecisionOperation(),
        new CreateUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdInstanceDecisionRecordAllDecisionOperation(),
        new DeleteUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdInstanceDecisionByIdOperation(),
        new GetUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdInstanceDecisionByIdOperation(),
        new GetUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdInstanceDecisionCountOperation(),
        new ListUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdInstanceDecisionsOperation(),
        new UpdateUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdInstanceDecisionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdInstanceDecisionRecordAllDecisionRequestModel)
    };
}
