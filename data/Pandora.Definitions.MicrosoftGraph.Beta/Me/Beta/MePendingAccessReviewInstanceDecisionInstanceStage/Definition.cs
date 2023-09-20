// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePendingAccessReviewInstanceDecisionInstanceStage;

internal class Definition : ResourceDefinition
{
    public string Name => "MePendingAccessReviewInstanceDecisionInstanceStage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMePendingAccessReviewInstanceByIdDecisionByIdInstanceStageOperation(),
        new DeleteMePendingAccessReviewInstanceByIdDecisionByIdInstanceStageByIdOperation(),
        new GetMePendingAccessReviewInstanceByIdDecisionByIdInstanceStageByIdOperation(),
        new GetMePendingAccessReviewInstanceByIdDecisionByIdInstanceStageCountOperation(),
        new ListMePendingAccessReviewInstanceByIdDecisionByIdInstanceStagesOperation(),
        new StopMePendingAccessReviewInstanceByIdDecisionByIdInstanceStageByIdOperation(),
        new UpdateMePendingAccessReviewInstanceByIdDecisionByIdInstanceStageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
