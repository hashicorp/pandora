// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarGroupCalendarEvent;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarGroupCalendarEvent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdAcceptOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdCancelOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdDeclineOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdDismissReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdForwardOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdTentativelyAcceptOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventOperation(),
        new DeleteUserByIdCalendarGroupByIdCalendarByIdEventByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdEventByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdEventCountOperation(),
        new ListUserByIdCalendarGroupByIdCalendarByIdEventsOperation(),
        new UpdateUserByIdCalendarGroupByIdCalendarByIdEventByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdTentativelyAcceptRequestModel)
    };
}
