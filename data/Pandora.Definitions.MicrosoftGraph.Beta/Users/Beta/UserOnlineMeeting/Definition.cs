// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnlineMeeting;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnlineMeeting";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnlineMeetingByIdSendVirtualAppointmentReminderSmOperation(),
        new CreateUserByIdOnlineMeetingByIdSendVirtualAppointmentSmOperation(),
        new CreateUserByIdOnlineMeetingCreateOrGetOperation(),
        new CreateUserByIdOnlineMeetingOperation(),
        new DeleteUserByIdOnlineMeetingByIdOperation(),
        new GetUserByIdOnlineMeetingByIdOperation(),
        new GetUserByIdOnlineMeetingCountOperation(),
        new ListUserByIdOnlineMeetingsOperation(),
        new UpdateUserByIdOnlineMeetingByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CreateUserByIdOnlineMeetingByIdSendVirtualAppointmentReminderSmRequestRemindBeforeTimeInMinutesTypeConstant),
        typeof(CreateUserByIdOnlineMeetingByIdSendVirtualAppointmentSmRequestSmsTypeConstant)
    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOnlineMeetingByIdSendVirtualAppointmentReminderSmRequestModel),
        typeof(CreateUserByIdOnlineMeetingByIdSendVirtualAppointmentSmRequestModel),
        typeof(CreateUserByIdOnlineMeetingCreateOrGetRequestModel)
    };
}
