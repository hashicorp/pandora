// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceEnrollmentConfiguration;

internal class Definition : ResourceDefinition
{
    public string Name => "MeDeviceEnrollmentConfiguration";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AssignMeDeviceEnrollmentConfigurationByIdOperation(),
        new CreateMeDeviceEnrollmentConfigurationCreateEnrollmentNotificationConfigurationOperation(),
        new CreateMeDeviceEnrollmentConfigurationHasPayloadLinkOperation(),
        new CreateMeDeviceEnrollmentConfigurationOperation(),
        new DeleteMeDeviceEnrollmentConfigurationByIdOperation(),
        new GetMeDeviceEnrollmentConfigurationByIdOperation(),
        new GetMeDeviceEnrollmentConfigurationCountOperation(),
        new ListMeDeviceEnrollmentConfigurationsOperation(),
        new SetMeDeviceEnrollmentConfigurationByIdPriorityOperation(),
        new UpdateMeDeviceEnrollmentConfigurationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AssignMeDeviceEnrollmentConfigurationByIdRequestModel),
        typeof(CreateMeDeviceEnrollmentConfigurationCreateEnrollmentNotificationConfigurationRequestModel),
        typeof(CreateMeDeviceEnrollmentConfigurationHasPayloadLinkRequestModel),
        typeof(SetMeDeviceEnrollmentConfigurationByIdPriorityRequestModel)
    };
}
