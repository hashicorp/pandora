// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarEventInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarEventInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdCancelOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdForwardOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarByIdEventByIdInstanceByIdTentativelyAcceptOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdCancelOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdForwardOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarEventByIdInstanceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarByIdEventByIdInstanceByIdOperation(),
        new GetUserByIdCalendarByIdEventByIdInstanceCountOperation(),
        new GetUserByIdCalendarEventByIdInstanceByIdOperation(),
        new GetUserByIdCalendarEventByIdInstanceCountOperation(),
        new ListUserByIdCalendarByIdEventByIdInstancesOperation(),
        new ListUserByIdCalendarEventByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarByIdEventByIdInstanceByIdTentativelyAcceptRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarEventByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
