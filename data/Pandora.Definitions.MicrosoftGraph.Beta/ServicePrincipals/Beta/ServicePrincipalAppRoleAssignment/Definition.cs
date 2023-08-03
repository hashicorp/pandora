// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalAppRoleAssignment;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipalAppRoleAssignment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateAppRoleAssignmentOperation(),
        new DeleteAppRoleAssignmentOperation(),
        new GetAppRoleAssignmentOperation(),
        new GetServicePrincipalAppRoleAssignmentsCountOperation(),
        new ListAppRoleAssignmentsOperation(),
        new UpdateAppRoleAssignmentOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
