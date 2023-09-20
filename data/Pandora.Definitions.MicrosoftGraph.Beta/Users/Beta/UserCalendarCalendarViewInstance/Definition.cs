// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCalendarCalendarViewInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarCalendarViewInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdCancelOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdForwardOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdTentativelyAcceptOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdCancelOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdForwardOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarCalendarViewByIdInstanceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdInstanceByIdOperation(),
        new GetUserByIdCalendarByIdCalendarViewByIdInstanceCountOperation(),
        new GetUserByIdCalendarCalendarViewByIdInstanceByIdOperation(),
        new GetUserByIdCalendarCalendarViewByIdInstanceCountOperation(),
        new ListUserByIdCalendarByIdCalendarViewByIdInstancesOperation(),
        new ListUserByIdCalendarCalendarViewByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarByIdCalendarViewByIdInstanceByIdTentativelyAcceptRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarCalendarViewByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
