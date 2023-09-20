// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDeviceEnrollmentConfiguration;

internal class Definition : ResourceDefinition
{
    public string Name => "UserDeviceEnrollmentConfiguration";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AssignUserByIdDeviceEnrollmentConfigurationByIdOperation(),
        new CreateUserByIdDeviceEnrollmentConfigurationCreateEnrollmentNotificationConfigurationOperation(),
        new CreateUserByIdDeviceEnrollmentConfigurationHasPayloadLinkOperation(),
        new CreateUserByIdDeviceEnrollmentConfigurationOperation(),
        new DeleteUserByIdDeviceEnrollmentConfigurationByIdOperation(),
        new GetUserByIdDeviceEnrollmentConfigurationByIdOperation(),
        new GetUserByIdDeviceEnrollmentConfigurationCountOperation(),
        new ListUserByIdDeviceEnrollmentConfigurationsOperation(),
        new SetUserByIdDeviceEnrollmentConfigurationByIdPriorityOperation(),
        new UpdateUserByIdDeviceEnrollmentConfigurationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AssignUserByIdDeviceEnrollmentConfigurationByIdRequestModel),
        typeof(CreateUserByIdDeviceEnrollmentConfigurationCreateEnrollmentNotificationConfigurationRequestModel),
        typeof(CreateUserByIdDeviceEnrollmentConfigurationHasPayloadLinkRequestModel),
        typeof(SetUserByIdDeviceEnrollmentConfigurationByIdPriorityRequestModel)
    };
}
