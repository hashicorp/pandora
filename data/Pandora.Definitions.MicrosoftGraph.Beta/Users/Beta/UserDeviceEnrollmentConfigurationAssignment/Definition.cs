// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDeviceEnrollmentConfigurationAssignment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserDeviceEnrollmentConfigurationAssignment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdDeviceEnrollmentConfigurationByIdAssignmentOperation(),
        new DeleteUserByIdDeviceEnrollmentConfigurationByIdAssignmentByIdOperation(),
        new GetUserByIdDeviceEnrollmentConfigurationByIdAssignmentByIdOperation(),
        new GetUserByIdDeviceEnrollmentConfigurationByIdAssignmentCountOperation(),
        new ListUserByIdDeviceEnrollmentConfigurationByIdAssignmentsOperation(),
        new UpdateUserByIdDeviceEnrollmentConfigurationByIdAssignmentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
