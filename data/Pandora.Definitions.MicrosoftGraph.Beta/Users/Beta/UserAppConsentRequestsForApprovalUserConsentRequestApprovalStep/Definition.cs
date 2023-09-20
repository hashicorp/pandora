// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserAppConsentRequestsForApprovalUserConsentRequestApprovalStep;

internal class Definition : ResourceDefinition
{
    public string Name => "UserAppConsentRequestsForApprovalUserConsentRequestApprovalStep";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdAppConsentRequestsForApprovalByIdUserConsentRequestByIdApprovalStepOperation(),
        new DeleteUserByIdAppConsentRequestsForApprovalByIdUserConsentRequestByIdApprovalStepByIdOperation(),
        new GetUserByIdAppConsentRequestsForApprovalByIdUserConsentRequestByIdApprovalStepByIdOperation(),
        new GetUserByIdAppConsentRequestsForApprovalByIdUserConsentRequestByIdApprovalStepCountOperation(),
        new ListUserByIdAppConsentRequestsForApprovalByIdUserConsentRequestByIdApprovalStepsOperation(),
        new UpdateUserByIdAppConsentRequestsForApprovalByIdUserConsentRequestByIdApprovalStepByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
