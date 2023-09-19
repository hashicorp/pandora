// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MePendingAccessReviewInstanceContactedReviewer;

internal class Definition : ResourceDefinition
{
    public string Name => "MePendingAccessReviewInstanceContactedReviewer";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMePendingAccessReviewInstanceByIdContactedReviewerOperation(),
        new DeleteMePendingAccessReviewInstanceByIdContactedReviewerByIdOperation(),
        new GetMePendingAccessReviewInstanceByIdContactedReviewerByIdOperation(),
        new GetMePendingAccessReviewInstanceByIdContactedReviewerCountOperation(),
        new ListMePendingAccessReviewInstanceByIdContactedReviewersOperation(),
        new UpdateMePendingAccessReviewInstanceByIdContactedReviewerByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
