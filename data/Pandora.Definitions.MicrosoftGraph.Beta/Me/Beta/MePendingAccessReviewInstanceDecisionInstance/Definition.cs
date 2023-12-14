// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePendingAccessReviewInstanceDecisionInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "MePendingAccessReviewInstanceDecisionInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMePendingAccessReviewInstanceByIdDecisionByIdInstanceAcceptRecommendationOperation(),
        new CreateMePendingAccessReviewInstanceByIdDecisionByIdInstanceApplyDecisionOperation(),
        new CreateMePendingAccessReviewInstanceByIdDecisionByIdInstanceBatchRecordDecisionOperation(),
        new CreateMePendingAccessReviewInstanceByIdDecisionByIdInstanceResetDecisionOperation(),
        new CreateMePendingAccessReviewInstanceByIdDecisionByIdInstanceSendReminderOperation(),
        new DeleteMePendingAccessReviewInstanceByIdDecisionByIdInstanceOperation(),
        new GetMePendingAccessReviewInstanceByIdDecisionByIdInstanceOperation(),
        new StopMePendingAccessReviewInstanceByIdDecisionByIdInstanceApplyDecisionOperation(),
        new StopMePendingAccessReviewInstanceByIdDecisionByIdInstanceOperation(),
        new UpdateMePendingAccessReviewInstanceByIdDecisionByIdInstanceOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMePendingAccessReviewInstanceByIdDecisionByIdInstanceBatchRecordDecisionRequestModel)
    };
}
