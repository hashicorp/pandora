// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipalAppRoleAssignment;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipalAppRoleAssignment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateServicePrincipalByIdAppRoleAssignmentOperation(),
        new DeleteServicePrincipalByIdAppRoleAssignmentByIdOperation(),
        new GetServicePrincipalByIdAppRoleAssignmentByIdOperation(),
        new GetServicePrincipalByIdAppRoleAssignmentCountOperation(),
        new ListServicePrincipalByIdAppRoleAssignmentsOperation(),
        new UpdateServicePrincipalByIdAppRoleAssignmentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
