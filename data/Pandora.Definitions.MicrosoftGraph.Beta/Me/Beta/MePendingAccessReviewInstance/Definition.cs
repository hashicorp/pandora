// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePendingAccessReviewInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "MePendingAccessReviewInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMePendingAccessReviewInstanceByIdAcceptRecommendationOperation(),
        new CreateMePendingAccessReviewInstanceByIdApplyDecisionOperation(),
        new CreateMePendingAccessReviewInstanceByIdBatchRecordDecisionOperation(),
        new CreateMePendingAccessReviewInstanceByIdResetDecisionOperation(),
        new CreateMePendingAccessReviewInstanceByIdSendReminderOperation(),
        new CreateMePendingAccessReviewInstanceOperation(),
        new DeleteMePendingAccessReviewInstanceByIdOperation(),
        new GetMePendingAccessReviewInstanceByIdOperation(),
        new GetMePendingAccessReviewInstanceCountOperation(),
        new ListMePendingAccessReviewInstancesOperation(),
        new StopMePendingAccessReviewInstanceByIdApplyDecisionOperation(),
        new StopMePendingAccessReviewInstanceByIdOperation(),
        new UpdateMePendingAccessReviewInstanceByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMePendingAccessReviewInstanceByIdBatchRecordDecisionRequestModel)
    };
}
