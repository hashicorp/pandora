// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInformationProtectionThreatAssessmentRequestResult;

internal class Definition : ResourceDefinition
{
    public string Name => "MeInformationProtectionThreatAssessmentRequestResult";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeInformationProtectionThreatAssessmentRequestByIdResultOperation(),
        new DeleteMeInformationProtectionThreatAssessmentRequestByIdResultByIdOperation(),
        new GetMeInformationProtectionThreatAssessmentRequestByIdResultByIdOperation(),
        new GetMeInformationProtectionThreatAssessmentRequestByIdResultCountOperation(),
        new ListMeInformationProtectionThreatAssessmentRequestByIdResultsOperation(),
        new UpdateMeInformationProtectionThreatAssessmentRequestByIdResultByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
