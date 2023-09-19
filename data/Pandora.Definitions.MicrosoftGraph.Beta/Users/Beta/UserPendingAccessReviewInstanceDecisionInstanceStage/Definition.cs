// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPendingAccessReviewInstanceDecisionInstanceStage;

internal class Definition : ResourceDefinition
{
    public string Name => "UserPendingAccessReviewInstanceDecisionInstanceStage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceStageOperation(),
        new DeleteUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceStageByIdOperation(),
        new GetUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceStageByIdOperation(),
        new GetUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceStageCountOperation(),
        new ListUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceStagesOperation(),
        new StopUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceStageByIdOperation(),
        new UpdateUserByIdPendingAccessReviewInstanceByIdDecisionByIdInstanceStageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
