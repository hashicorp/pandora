// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstanceStageDecision;

internal class Definition : ResourceDefinition
{
    public string Name => "UserPendingAccessReviewInstanceStageDecision";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionOperation(),
        new CreateUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionRecordAllDecisionOperation(),
        new DeleteUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdOperation(),
        new GetUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdOperation(),
        new GetUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionCountOperation(),
        new ListUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionsOperation(),
        new UpdateUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdPendingAccessReviewInstanceByIdStageByIdDecisionRecordAllDecisionRequestModel)
    };
}
