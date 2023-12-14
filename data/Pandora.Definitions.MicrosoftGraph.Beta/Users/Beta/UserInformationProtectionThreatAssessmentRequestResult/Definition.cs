// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionThreatAssessmentRequestResult;

internal class Definition : ResourceDefinition
{
    public string Name => "UserInformationProtectionThreatAssessmentRequestResult";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdInformationProtectionThreatAssessmentRequestByIdResultOperation(),
        new DeleteUserByIdInformationProtectionThreatAssessmentRequestByIdResultByIdOperation(),
        new GetUserByIdInformationProtectionThreatAssessmentRequestByIdResultByIdOperation(),
        new GetUserByIdInformationProtectionThreatAssessmentRequestByIdResultCountOperation(),
        new ListUserByIdInformationProtectionThreatAssessmentRequestByIdResultsOperation(),
        new UpdateUserByIdInformationProtectionThreatAssessmentRequestByIdResultByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
