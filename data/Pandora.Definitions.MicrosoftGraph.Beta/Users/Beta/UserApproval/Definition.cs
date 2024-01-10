// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserApproval;

internal class Definition : ResourceDefinition
{
    public string Name => "UserApproval";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdApprovalOperation(),
        new DeleteUserByIdApprovalByIdOperation(),
        new GetUserByIdApprovalByIdOperation(),
        new GetUserByIdApprovalCountOperation(),
        new ListUserByIdApprovalsOperation(),
        new UpdateUserByIdApprovalByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
