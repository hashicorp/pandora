// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "UserPendingAccessReviewInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdPendingAccessReviewInstanceByIdAcceptRecommendationOperation(),
        new CreateUserByIdPendingAccessReviewInstanceByIdApplyDecisionOperation(),
        new CreateUserByIdPendingAccessReviewInstanceByIdBatchRecordDecisionOperation(),
        new CreateUserByIdPendingAccessReviewInstanceByIdResetDecisionOperation(),
        new CreateUserByIdPendingAccessReviewInstanceByIdSendReminderOperation(),
        new CreateUserByIdPendingAccessReviewInstanceOperation(),
        new DeleteUserByIdPendingAccessReviewInstanceByIdOperation(),
        new GetUserByIdPendingAccessReviewInstanceByIdOperation(),
        new GetUserByIdPendingAccessReviewInstanceCountOperation(),
        new ListUserByIdPendingAccessReviewInstancesOperation(),
        new StopUserByIdPendingAccessReviewInstanceByIdApplyDecisionOperation(),
        new StopUserByIdPendingAccessReviewInstanceByIdOperation(),
        new UpdateUserByIdPendingAccessReviewInstanceByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdPendingAccessReviewInstanceByIdBatchRecordDecisionRequestModel)
    };
}
