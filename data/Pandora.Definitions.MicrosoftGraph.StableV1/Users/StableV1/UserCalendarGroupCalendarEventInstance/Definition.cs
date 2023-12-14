// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarGroupCalendarEventInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarGroupCalendarEventInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdCancelOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdForwardOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceCountOperation(),
        new ListUserByIdCalendarGroupByIdCalendarByIdEventByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdEventByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
