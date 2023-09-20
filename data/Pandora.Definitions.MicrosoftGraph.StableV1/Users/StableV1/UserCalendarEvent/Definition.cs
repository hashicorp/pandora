// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarEvent;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarEvent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdEventByIdAcceptOperation(),
        new CreateUserByIdCalendarByIdEventByIdCancelOperation(),
        new CreateUserByIdCalendarByIdEventByIdDeclineOperation(),
        new CreateUserByIdCalendarByIdEventByIdDismissReminderOperation(),
        new CreateUserByIdCalendarByIdEventByIdForwardOperation(),
        new CreateUserByIdCalendarByIdEventByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarByIdEventByIdTentativelyAcceptOperation(),
        new CreateUserByIdCalendarByIdEventOperation(),
        new CreateUserByIdCalendarEventByIdAcceptOperation(),
        new CreateUserByIdCalendarEventByIdCancelOperation(),
        new CreateUserByIdCalendarEventByIdDeclineOperation(),
        new CreateUserByIdCalendarEventByIdDismissReminderOperation(),
        new CreateUserByIdCalendarEventByIdForwardOperation(),
        new CreateUserByIdCalendarEventByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarEventByIdTentativelyAcceptOperation(),
        new CreateUserByIdCalendarEventOperation(),
        new DeleteUserByIdCalendarByIdEventByIdOperation(),
        new DeleteUserByIdCalendarEventByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdOperation(),
        new GetUserByIdCalendarByIdEventCountOperation(),
        new GetUserByIdCalendarEventByIdOperation(),
        new GetUserByIdCalendarEventCountOperation(),
        new ListUserByIdCalendarByIdEventsOperation(),
        new ListUserByIdCalendarEventsOperation(),
        new UpdateUserByIdCalendarByIdEventByIdOperation(),
        new UpdateUserByIdCalendarEventByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdEventByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdTentativelyAcceptRequestModel),
        typeof(CreateUserByIdCalendarEventByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarEventByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarEventByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarEventByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarEventByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarEventByIdTentativelyAcceptRequestModel)
    };
}
