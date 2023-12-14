// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePendingAccessReviewInstanceDecisionInstanceContactedReviewer;

internal class Definition : ResourceDefinition
{
    public string Name => "MePendingAccessReviewInstanceDecisionInstanceContactedReviewer";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMePendingAccessReviewInstanceByIdDecisionByIdInstanceContactedReviewerOperation(),
        new DeleteMePendingAccessReviewInstanceByIdDecisionByIdInstanceContactedReviewerByIdOperation(),
        new GetMePendingAccessReviewInstanceByIdDecisionByIdInstanceContactedReviewerByIdOperation(),
        new GetMePendingAccessReviewInstanceByIdDecisionByIdInstanceContactedReviewerCountOperation(),
        new ListMePendingAccessReviewInstanceByIdDecisionByIdInstanceContactedReviewersOperation(),
        new UpdateMePendingAccessReviewInstanceByIdDecisionByIdInstanceContactedReviewerByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
