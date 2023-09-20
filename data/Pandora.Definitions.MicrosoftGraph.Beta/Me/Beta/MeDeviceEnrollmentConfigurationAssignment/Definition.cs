// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceEnrollmentConfigurationAssignment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeDeviceEnrollmentConfigurationAssignment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeDeviceEnrollmentConfigurationByIdAssignmentOperation(),
        new DeleteMeDeviceEnrollmentConfigurationByIdAssignmentByIdOperation(),
        new GetMeDeviceEnrollmentConfigurationByIdAssignmentByIdOperation(),
        new GetMeDeviceEnrollmentConfigurationByIdAssignmentCountOperation(),
        new ListMeDeviceEnrollmentConfigurationByIdAssignmentsOperation(),
        new UpdateMeDeviceEnrollmentConfigurationByIdAssignmentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
