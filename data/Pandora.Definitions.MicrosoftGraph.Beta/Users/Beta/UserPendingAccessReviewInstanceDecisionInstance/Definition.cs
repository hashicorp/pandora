// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstanceDecisionInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "UserPendingAccessReviewInstanceDecisionInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceAcceptRecommendationOperation(),
        new CreateUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceApplyDecisionOperation(),
        new CreateUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceBatchRecordDecisionOperation(),
        new CreateUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceResetDecisionOperation(),
        new CreateUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceSendReminderOperation(),
        new DeleteUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceOperation(),
        new GetUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceOperation(),
        new StopUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceApplyDecisionOperation(),
        new StopUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceOperation(),
        new UpdateUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceBatchRecordDecisionRequestModel)
    };
}
