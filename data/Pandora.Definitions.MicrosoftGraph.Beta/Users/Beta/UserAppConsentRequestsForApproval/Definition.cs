// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserAppConsentRequestsForApproval;

internal class Definition : ResourceDefinition
{
    public string Name => "UserAppConsentRequestsForApproval";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdAppConsentRequestsForApprovalOperation(),
        new DeleteUserByIdAppConsentRequestsForApprovalByIdOperation(),
        new GetUserByIdAppConsentRequestsForApprovalByIdOperation(),
        new GetUserByIdAppConsentRequestsForApprovalCountOperation(),
        new ListUserByIdAppConsentRequestsForApprovalsOperation(),
        new UpdateUserByIdAppConsentRequestsForApprovalByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
