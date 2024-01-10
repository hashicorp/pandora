// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeApprovalStep;

internal class Definition : ResourceDefinition
{
    public string Name => "MeApprovalStep";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeApprovalByIdStepOperation(),
        new DeleteMeApprovalByIdStepByIdOperation(),
        new GetMeApprovalByIdStepByIdOperation(),
        new GetMeApprovalByIdStepCountOperation(),
        new ListMeApprovalByIdStepsOperation(),
        new UpdateMeApprovalByIdStepByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
